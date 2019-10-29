echo "Build api..."
sleep 3

docker build -t eport-redis-api .
docker build -t eport-redis-nginx ./nginx

echo "Build eport_redis_api..."
sleep 2

docker-compose -f docker-compose.yml up -d --build

docker ps -a