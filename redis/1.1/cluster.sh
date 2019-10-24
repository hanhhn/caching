network_database='net_database'
#---------- create the cluster ------------------------

cluster_hosts=''

for port in `seq 7001 7006`; do \
 hostip=`docker inspect -f '{{(index .NetworkSettings.Networks "network_database").IPAddress}}' "redis-"$port`;
 echo "IP for cluster node redis-"$port "is" $hostip
 cluster_hosts="$cluster_hosts$hostip:$port ";
done

echo "cluster hosts "$cluster_hosts
# echo "creating cluster...."
# echo 'yes' | docker run -i --rm --net $network_name $redis_image redis-cli --cluster create $cluster_hosts --cluster-replicas 3;