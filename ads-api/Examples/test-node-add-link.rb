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

apiUrl = "api/Node/org/#{orgId}/action/AddLink/#{id}"
param = {
  Name: "link1",
  Description: "link2 description",
  Tags: "yyy",
  DestinationNode: "e618409f-8496-4cce-ac72-7775d9e97c21",
}

result = make_request(:post, apiUrl, param)
puts(result)
