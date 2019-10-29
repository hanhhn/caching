FROM redis:5.0.6

LABEL maintainer="hanhhn@saigonnewport.com.vn"

COPY app.conf /usr/local/etc/redis/redis.conf

EXPOSE 6379

VOLUME [ "/data" ]

CMD [ "redis-server", "/usr/local/etc/redis/redis.conf" ]