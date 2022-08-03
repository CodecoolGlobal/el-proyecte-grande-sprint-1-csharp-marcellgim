# Stage 1: Build

FROM node:lts-alpine as build
WORKDIR /app
COPY ["package.json", "package-lock.json*", "npm-shrinkwrap.json*", ".env*", "./"]
RUN npm ci
COPY . ./
RUN npm run build


# Stage 2: Serve
FROM nginx:latest
ENV PORT=3000
COPY --from=build /app/build /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf.template

CMD /bin/bash -c "envsubst '\$PORT' < /etc/nginx/conf.d/default.conf.template > /etc/nginx/conf.d/default.conf" && nginx -g 'daemon off;'