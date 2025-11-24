#!/usr/bin/env ruby

require 'net/http'
require 'uri'
require 'json'
require './utils'

$stdout.sync = true

################### Main #######################
load_env(".env")

orgId = ENV['API_ORG']

apiUrl1 = "api/Analytic/org/#{orgId}/action/GetMitreStats"
param = {
  "FromDate": "2025-11-01T00:00:00Z",
  "ToDate": "2025-11-30T23:59:59Z"
}

result = make_request(:post, apiUrl1, param)
json_str = result.to_json

puts(json_str)
