#!/usr/bin/env ruby

require 'net/http'
require 'uri'
require 'json'
require './utils'

$stdout.sync = true

################### Main #######################
load_env(".env")

orgId = ENV['API_ORG']

apiUrl = "api/Node/org/#{orgId}/action/AddNode"
param =  {
  Name: "RTARF-HQ-ROUTER-002",
  Description: "Head quater router",
  Tags: "test",
  Layer: "Internal",
  Type: "Router",
  Latitude: 10.54,
  Longitude: 9.87,
}

result = make_request(:post, apiUrl, param)
puts(result)
