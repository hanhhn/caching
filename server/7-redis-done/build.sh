echo "Implement for Docker version 18.09.7"
echo "Current version: " && docker --version

for port in `seq 6001 6009`; do \
    sudo rm -rf "/app/redis/"$port
    echo "remove /app/redis/"$port
done

docker-compose -f docker-compose.yml up -d --build

sleep 3

docker ps -a

#---------- create the cluster ------------------------

cluster_hosts=''


echo "../hostip.txt"
sudo rm -rf "../hostip.txt"

for port in `seq 6001 6009`; do \
    hostip=`docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' "redis-"$port`
    echo "IP for cluster node redis-"$port "is "$hostip":6379";
    cluster_hosts="$cluster_hosts$hostip:6379 ";
    echo $hostip":6379" >> ../hostip.txt
done

sleep 5

echo "Cluster hosts "$cluster_hosts
echo "creating cluster...."
echo 'yes' | docker run -i --rm --net host redis:latest redis-cli --cluster create $cluster_hosts --cluster-replicas 2;

# for port in `seq 17001 17009`; do \
#     sudo ufw delete allow $port
# done
