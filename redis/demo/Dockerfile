FROM redis:5.0.6

ARG fileconfig=app.conf

LABEL maintainer="hanhhn@saigonnewport.com.vn"

COPY $fileconfig /usr/local/etc/redis/redis.conf

EXPOSE 6379

VOLUME [ "/data" ]

CMD [ "redis-server", "/usr/local/etc/redis/redis.conf" ]