#!/usr/bin/env ruby

require 'net/http'
require 'uri'
require 'json'
require './utils'

$stdout.sync = true

################### Main #######################
load_env(".env")

orgId = ENV['API_ORG']
id = 'dd08a261-d36c-4ad9-adad-9534f31259aa'

apiUrl = "api/Node/org/#{orgId}/action/AddLink/#{id}"
param = {
  Name: "link1",
  Description: "link2 description",
  Tags: "yyy",
  DestinationNode: "f99a4a2f-6b83-4d15-a508-c0525157d40a",
}

result = make_request(:post, apiUrl, param)
puts(result)
