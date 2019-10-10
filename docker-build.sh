sudo git pull
sudo docker ps -a
sudo docker-compose -f docker-compose.yml up --detach --scale master=3 --build --remove-orphans --force-recreate