echo "Uninstall redis api..."
docker-compose down

echo "Uninstall redis sever..."
cd server/6-redis-api-done/
docker-compose down