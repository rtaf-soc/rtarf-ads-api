#!/usr/bin/env ruby
# Usage : ./test-api.rb <environment> <api-name> 

require 'yaml'
require "json"
require "base64"
require 'net/http'

require './env'

##### Functions #####
def get_api_key(endpointObj)
  userVarName = endpointObj['basicAuthenUserEnvVar']
  passwordVarName = endpointObj['basicAuthenPasswordEnvVar']

  user = ENV[userVarName]
  password = ENV[passwordVarName]

  key = "Basic " + Base64::strict_encode64("#{user}:#{password}")
#puts ("=== [#{user}] [#{password}] [#{key}] ===\n")
  return key
end

def invoke_api(orgId, apiName, apiObj, endpointObj, dataObj)
  endpoint = endpointObj['uri']
  method = apiObj['method']
  path = apiObj['path']
  controller = apiObj['controller']
  bodyName = apiObj['body']
  bodyObj = dataObj[bodyName]

  if (!bodyName.nil? && bodyObj.nil?)
    puts("ERROR : Data object [#{bodyName}] not found in [data] section!!!\n")
    return 
  end

  puts("INFO : Requesting API [#{apiName}] to [#{endpoint}]...\n")
  puts("INFO : Using method [#{method}]\n")

  uri = "#{endpoint}/api/#{controller}/org/#{orgId}/action/#{apiName}#{path}"
  puts("INFO : Using URI [#{uri}]\n")

  uriObj = URI.parse(uri)
  api_key = get_api_key(endpointObj)

  https = Net::HTTP.new(uriObj.host, uriObj.port)
  https.use_ssl = true
  https.verify_mode = OpenSSL::SSL::VERIFY_NONE
  https.read_timeout = 0.5
  https.open_timeout = 0.5
  https.max_retries = 0

  jsonStr = ''

  request = Net::HTTP::Get.new(uriObj.path)
  if (method == 'POST')
    request = Net::HTTP::Post.new(uriObj.path)
    jsonStr = '{}'
  end

  if (!bodyObj.nil?)
    # Convert to JSON
    jsonStr = bodyObj.to_json
    #puts(jsonStr)
  end

  request['Accept'] = 'application/json'
  request['Content-Type'] = 'application/json'
  request['Authorization'] = api_key
  request.body = jsonStr

  status = ""
  begin
    response = https.request(request)
  #rescue
  #    status = 'ERROR'
  #else
      #No error
      status = response.code
      responseStr = response.body
  end

  puts("INFO : Returned with status code [#{status}]\n")
  if (status == "200")
    puts("INFO : ===== Begin response data =====\n")
    puts("#{responseStr}\n")
    puts("INFO : ===== End response data =====\n")
  end
end

##### Main #####
argCount = ARGV.length

if (argCount != 2)
  puts("ERROR : Invalid number of parameter!!!\n")
  puts("USAGE : ./test-api.rb <environment> <api-name>\n")

  return
end

orgId = 'default'
envName = ARGV[0]
apiName = ARGV[1]

puts("INFO : Testing API [#{apiName}] for environment [#{envName}]...\n")

cfg = YAML.load_file('api.yaml')

apiObj = cfg['api'][apiName]
if (apiObj.nil?)
  puts("ERROR : API [#{apiName}] not found!!!\n")
  return 
end

endpointObj = cfg['endpoint'][envName]
if (endpointObj.nil?)
  puts("ERROR : Environment [#{envName}] not found!!!\n")
  return 
end

dataObj = cfg['data']

invoke_api(orgId, apiName, apiObj, endpointObj, dataObj)