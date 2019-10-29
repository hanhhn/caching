echo "Build api..."
sleep 3

docker build -f Dockerfile --build --label eport-redis-api
docker build -f nginx/Dockerfile --build --label eport-redis-nginx

echo "Build eport_redis service"
sleep 2

docker-compose stack deploy -f docker-compose.yml  eport_redis
docker-compose stack ls