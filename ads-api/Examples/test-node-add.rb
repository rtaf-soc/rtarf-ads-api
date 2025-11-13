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
  Name: "RTARF-HQ-ROUTER-004",
  Description: "Head quater router",
  Tags: "test",
  Layer: "RTARF-Internal",
  Type: "Router",
  Latitude: 19.54,
  Longitude: 5.87,
}

result = make_request(:post, apiUrl, param)
puts(result)
