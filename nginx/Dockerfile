FROM nginx:latest

LABEL maintainer="hanhhn@saigonnewport.com.vn"

COPY app.conf /etc/nginx/nginx.conf

EXPOSE 80

EXPOSE 443

VOLUME [ "/etc/nginx/" ]

CMD ["nginx", "-g", "daemon off;"]