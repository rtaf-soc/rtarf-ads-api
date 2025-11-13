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
  DestinationNode: "c2b5bf17-437a-4c4f-acd4-f9ab99de3593",
}

result = make_request(:post, apiUrl, param)
puts(result)
