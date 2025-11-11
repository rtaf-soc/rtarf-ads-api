#!/usr/bin/env ruby

require 'net/http'
require 'uri'
require 'json'
require './utils'

$stdout.sync = true

################### Main #######################
load_env(".env")

orgId = ENV['API_ORG']
id = 'dce164ba-4116-4656-bc40-b7339814ba9c'

apiUrl = "api/Node/org/#{orgId}/action/GetNodeById/#{id}"
param = nil

result = make_request(:get, apiUrl, param)
puts(result)
