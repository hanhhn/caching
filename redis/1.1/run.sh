sudo git pull

for port in `seq 7001 7006`; do \
    sudo rm -rf "/app/redis/data-"$port
    echo "remove /app/redis/data-"$port
done

sudo docker-compose -f docker-compose.yml up -d --build
sudo docker ps -a
sudo bash cluster.sh

# sudo docker-compose -f docker-compose.yml up -d --build --remove-orphans --force-recreate