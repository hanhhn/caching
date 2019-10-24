sudo git pull

for port in `seq 7001 7006`; do \
    dir = sudo rm -rf "/app/redis/data-"$hostip
    echo "remove config "$dir && dir
done

sudo docker-compose -f docker-compose.yml up -d --build --remove-orphans --force-recreate
sudo docker ps -a
sudo bash cluster.sh