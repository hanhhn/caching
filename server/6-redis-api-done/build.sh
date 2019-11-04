echo "Implement for Docker version 18.09.7"
echo "Current version: " && docker --version

for port in `seq 7001 7009`; do \
    sudo rm -rf "/app/redis/"$port
    echo "remove /app/redis/"$port
done

docker build -t snp-redis

docker-compose -f docker-compose.yml up

sleep 3
cluster_hosts=''

echo "../hostip.txt"
sudo rm -rf "../hostip.txt"

for port in `seq 7001 7009`; do \
    hostip=`docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' "eport-redis-"$port`
    echo "IP for cluster node eport-redis-"$port "is "$hostip
    cluster_hosts="$cluster_hosts$hostip:6379 ";
    echo "$hostip:6379" >> ../hostip.txt
done

sleep 3

echo "Cluster hosts "$cluster_hosts
echo "creating cluster...."
echo 'yes' | docker run -i --rm --net host redis:latest redis-cli --cluster create $cluster_hosts --cluster-replicas 2;