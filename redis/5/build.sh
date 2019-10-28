for port in `seq 7001 7009`; do \
    sudo rm -rf "/app/redis/"$port
    echo "remove /app/redis/"$port
done

docker-compose -f docker-compose.yml up -d --build

sleep 3

docker ps -a
sudo bash cluster.sh

# sudo docker-compose -f docker-compose.yml up -d --build --remove-orphans --force-recreate