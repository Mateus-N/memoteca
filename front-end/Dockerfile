FROM nginx:1.21.3-alpine
RUN rm /etc/nginx/conf.d/default.conf
COPY nginx.conf /etc/nginx/conf.d/
COPY dist/memoteca /usr/share/nginx/html
