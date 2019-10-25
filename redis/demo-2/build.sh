sudo git pull

for port in `seq 7001 7006`; do \
    sudo rm -rf "/app/redis/"$port
    echo "remove /app/redis/"$port
done

docker-compose -f docker-compose.yml up -d --build

sleep 3

docker ps -a
sudo bash cluster.sh
