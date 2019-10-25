
echo "implement for Docker version 18.09.7"
echo "current version: " && docker --version
network_database='net_database'
#---------- create the cluster ------------------------

cluster_hosts=''

for port in `seq 7001 7006`; do \
    hostip=`172.16.50.189:$port`
    echo "IP for cluster node redis-"$port "is" $hostip
    cluster_hosts="$cluster_hosts$hostip ";
done

sleep 3

echo "cluster hosts "$cluster_hosts
echo "creating cluster...."
echo 'yes' | redis-cli --cluster create $cluster_hosts --cluster-replicas 1;

