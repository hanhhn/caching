
echo "implement for Docker version 18.09.7"
echo "current version: " && docker --version
network_database='net_database'
#---------- create the cluster ------------------------

cluster_hosts=''

for port in `seq 7001 7006`; do \
    hostip=`172.16.50.189:$port`;
    echo "IP for cluster node redis-"$port "is" $hostip
    cluster_hosts="$cluster_hosts$hostip ";
done

sleep 3

echo "cluster hosts "$cluster_hosts
echo "creating cluster...."
echo 'yes' |  docker run -i --rm --net host redis:latest redis-cli --cluster create 172.16.50.189:7001 172.16.50.189:7002 172.16.50.189:7003 172.16.50.189:7004 172.16.50.189:7005 172.16.50.189:7006 --cluster-replicas 1;

