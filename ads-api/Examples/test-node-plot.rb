#!/usr/bin/env ruby

require 'net/http'
require 'uri'
require 'json'
require './utils'

$stdout.sync = true

################### Main #######################
load_env(".env")

orgId = ENV['API_ORG']
layer = "RTARF-Internal" # ตรงนี้ต้องเรียก API GetLayers() แล้วเอา Name มาใช้

apiUrlGetNodes = "api/Node/org/#{orgId}/action/GetNodesByLayer/#{layer}"
param = nil

nodeHash = {}
links = []

ืnodes = make_request(:post, apiUrlGetNodes, param) # อนาคตเปลี่ยนเป็น method GET
ืnodes.each do |node|
  nodeId = node['id']
  puts(nodeId)

  # เอา node id มาเป็น unique เพื่อใช้ lookup หา Latitude, Longitude ในอนาคต
  nodeHash[nodeId] = node

  apiUrlGetNodeLinks = "api/Node/org/#{orgId}/action/GetNodeLinks/#{nodeId}"
  nodeLinks = make_request(:get, apiUrlGetNodeLinks, param)
  if (!nodeLinks.nil?)
    nodeLinks.each do |nodeLink|
      puts(nodeLink)
      links << nodeLink
    end
  end
end
