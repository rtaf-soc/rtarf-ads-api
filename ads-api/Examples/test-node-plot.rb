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
apiUrlGetNodesStatus = "api/Node/org/#{orgId}/action/GetNodesStatus/#{layer}"
param = nil

statusHash = {}
ืnodesStatus = make_request(:get, apiUrlGetNodesStatus, param)
ืnodesStatus.each do |nodeStatus|
  # เอา node id มาเป็น unique เพื่อใช้ lookup หา status ในอนาคต
  nodeId = nodeStatus['nodeId']
  statusHash[nodeId] = nodeStatus
end

nodeHash = {}
links = []

ืnodes = make_request(:get, apiUrlGetNodes, param)
ืnodes.each do |node|
  nodeId = node['id']
  #puts(nodeId)

  # เอา node id มาเป็น unique เพื่อใช้ lookup หา Latitude, Longitude ในอนาคต
  nodeHash[nodeId] = node

  # เอา link ที่เชื่อมต่ออยู่ไปยังอีก node
  apiUrlGetNodeLinks = "api/Node/org/#{orgId}/action/GetNodeLinks/#{nodeId}"
  nodeLinks = make_request(:get, apiUrlGetNodeLinks, param)
  if (!nodeLinks.nil?)
    nodeLinks.each do |nodeLink|
      #puts(nodeLink)
      links << nodeLink
    end
  end
end

nodeHash.each do |nodeId, node|
  nodeName = node['name']
  lat = node['latitude']
  lon = node['longitude']
  nodeStatusObj = statusHash[nodeId]

  statusJsonStr = ""
  if (!nodeStatusObj.nil?)
    #เวลาเอา status ไปใช้งานต้องเอา statusJsonStr ไปแปลงจาก string เป็น object ก่อน, status สามารถมีได้หลายมุมมอง เช่น treat count
    statusJsonStr = nodeStatusObj['status']
  end


  puts "Plotting node [#{nodeName}], lat=[#{lat}], lon=[#{lon}], nodeId=[#{nodeId}], status=[#{statusJsonStr}]"
end

# ดัดแปลง code ตรงนี้เอาไปทำให้เป็น JSON เพื่อให้ frontend เอาไปใช้งานง่าย ๆ 
links.each do |link|
  srcNodeId = link['sourceNode']
  dstNodeId = link['destinationNode']

  srcNode = nodeHash[srcNodeId]
  dstNode = nodeHash[dstNodeId]

  srcNodeName = srcNode['name']
  dstNodeName = dstNode['name']

  puts "Plotting link [#{srcNodeName}] ==> [#{dstNodeName}]"
end
