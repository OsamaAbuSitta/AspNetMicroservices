
# docker 
# check running containers 
 docker run -d -p 27017:27017 --name shopping-mongo mongo

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


