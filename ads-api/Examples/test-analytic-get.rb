#!/usr/bin/env ruby

require 'net/http'
require 'uri'
require 'json'
require './utils'

$stdout.sync = true

################### Main #######################
load_env(".env")

orgId = ENV['API_ORG']

apiUrl1 = "api/Analytic/org/#{orgId}/action/GetDefConStatus"
apiUrl2 = "api/Analytic/org/#{orgId}/action/GetReconCountries"
apiUrl3 = "api/Analytic/org/#{orgId}/action/GetThreatDistributions"
apiUrl4 = "api/Analytic/org/#{orgId}/action/GetThreatAlerts"

param = nil

result = make_request(:get, apiUrl1, param)
puts(result)
puts("===")

result = make_request(:get, apiUrl2, param)
puts(result)
puts("===")

result = make_request(:get, apiUrl3, param)
puts(result)
puts("===")

result = make_request(:get, apiUrl4, param)
puts(result)
puts("===")
