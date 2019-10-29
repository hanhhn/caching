echo "Build api..."
sleep 3

docker build -t eport-redis-api .
docker build -t eport-redis-nginx ./nginx

echo "Build eport_redis stack..."
sleep 2

docker stack deploy -c docker-compose.yml eport_redis
docker stack ps eport_redis