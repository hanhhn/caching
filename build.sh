echo "Build redis sever..."
sleep 3

bash server/6-redis-api/build.sh

echo "Build api..."
sleep 3

docker build -f Dockerfile --build --label eport-redis-api
docker build -f nginx/Dockerfile --build --label eport-redis-nginx
docker-compose stack deploy eport_redis
docker-compose stack ls