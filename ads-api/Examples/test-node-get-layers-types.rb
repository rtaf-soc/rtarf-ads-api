#!/usr/bin/env ruby

require 'net/http'
require 'uri'
require 'json'
require './utils'

$stdout.sync = true

################### Main #######################
load_env(".env")

orgId = ENV['API_ORG']
param = nil

apiUrl = "api/Node/org/#{orgId}/action/GetLayers"
result = make_request(:get, apiUrl, param)
puts(result)


apiUrl = "api/Node/org/#{orgId}/action/GetNodeTypes"
result = make_request(:get, apiUrl, param)
puts(result)
