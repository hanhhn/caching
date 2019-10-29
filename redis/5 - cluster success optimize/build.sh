echo "Implement for Docker version 18.09.7"
echo "Current version: " && docker --version

for port in `seq 7001 7009`; do \
    sudo rm -rf "/app/redis/"$port
    echo "remove /app/redis/"$port
    sudo ufw allow $port
done

for port in `seq 17001 17009`; do \
    sudo ufw allow $port
done


docker-compose -f docker-compose.yml up -d --build

sleep 3

docker ps -a

network_database='net_database'
#---------- create the cluster ------------------------

cluster_hosts=''

for port in `seq 7001 7009`; do \
    hostip=`hostname -I | awk '{print $1}'`
    echo "IP for cluster node redis-"$port "is "$hostip":"$port
    cluster_hosts="$cluster_hosts$hostip":"$port ";
done

sleep 5

echo $cluster_hosts > hostip.txt

echo "cluster hosts "$cluster_hosts
echo "creating cluster...."
echo 'yes' | docker run -i --rm --net host redis:latest redis-cli --cluster create $cluster_hosts --cluster-replicas 2;

# for port in `seq 17001 17009`; do \
#     sudo ufw delete allow $port
# done
