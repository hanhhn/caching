
echo "implement for Docker version 18.09.7"
echo "current version: " && docker --version
network_database='net_database_redis'
#---------- create the cluster ------------------------

cluster_hosts=''

for port in `seq 7001 7006`; do \
    hostip=`docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' "demo-2_redis-"$port"_1"`
    echo "IP for cluster node redis-"$port "is" $hostip
    cluster_hosts="$cluster_hosts$hostip:6379 ";
done

sleep 3

echo "cluster hosts "$cluster_hosts
echo "creating cluster...."
echo 'yes' | docker run -i --rm --net $network_database redis:latest redis-cli --cluster create $cluster_hosts --cluster-replicas 1;



docker run -i --rm --net net_database_redis redis:latest redis-cli --cluster create 172.20.0.7:6379 172.20.0.6:6379 172.20.0.4:6379 172.20.0.2:6379 172.20.0.5:6379 172.20.0.3:6379 --cluster-replicas 1;

