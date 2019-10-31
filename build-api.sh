echo "Build redis api..."
sleep 2

docker-compose -f docker-compose.yml up -d --build

docker ps -a