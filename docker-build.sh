sudo git pull
sudo docker ps -a
sudo docker-compose -f docker-compose.yml up --detach --scale redis-master=1 --scale redis-slave=4 --build --remove-orphans --force-recreate