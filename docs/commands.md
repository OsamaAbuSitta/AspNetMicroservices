
# docker 
# check running containers 

 docker ps 

 docker stop {id}
 docker rm {id}
 docker images

# docker-compose
 docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d

 docker-compose down


---

# Mongo
## run mongo
 docker run -d -p 27017:27017 --name shopping-mongo mongo


## check containr logs 
 docker run -d -p 27017:27017 --name shopping-mongo mongo

## open interactive mongo command / mongo cli
docker exec -it shopping-mongog /bing/bash

mongo
use CatalogDb
show dbs
db.createCollection('Products')
db.Products.insertMany([{"name": "test"}])
db.Products.insertMany([{"name": "test"}])

see mongo+commands.txt

-----------

# Redis
## https://hub.docker.com/_/redis
docker pull redis

## Check docker images 
docker run -d -p 6379:6379 --name aspnetrun-redis redis

## To get interactive command 
docker exec -it aspnetrun-redis /bin/bash



