sudo git pull
sudo docker ps -a
sudo docker-compose -f docker-compose.yml up --detach --build --remove-orphans --force-recreate scale redis=9