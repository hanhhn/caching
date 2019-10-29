echo "Build api..."
sleep 3

docker build -t eport-redis-api .
docker build -t eport-redis-nginx ./nginx

echo "Build eport_redis service"
sleep 2

docker-compose stack deploy -f docker-compose.yml  eport_redis
docker-compose stack lsdocker