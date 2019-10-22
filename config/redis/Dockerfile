FROM redis:5.0.6

COPY app.conf /usr/local/etc/redis/redis.conf

EXPOSE 6379

VOLUME [ "/data" ]

CMD [ "redis-server", "/usr/local/etc/redis/redis.conf" ]