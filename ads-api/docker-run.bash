#!/bin/bash

docker run -d \
  --name postgres-ads \
  -e POSTGRES_USER=postgres \
  -e POSTGRES_PASSWORD=thisispassword \
  -e POSTGRES_DB=ads \
  -v pgdata:/var/lib/postgresql/data \
  -p 5432:5432 \
  asia-southeast1-docker.pkg.dev/its-artifact-commons/utils/postgresql:v16.2.0-2
