FROM redis:latest

LABEL maintainer "hanhhn <hngochanh@outlook.com>"

COPY app.conf /usr/local/etc/redis/redis.conf

EXPOSE 6379

CMD [ "redis-server", "/usr/local/etc/redis/redis.conf" ]