docker ps -a
docker build -f Dockerfile --build --label eport-redis-api
docker build -f nginx/Dockerfile --build --label eport-redis-nginx
docker-compose stack deploy eport_redis