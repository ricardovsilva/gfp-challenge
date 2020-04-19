FROM node:13.12.0-alpine

ENV PATH /app/node_modules/.bin:$PATH

WORKDIR /app


COPY ./ .

RUN npm install
RUN npm test

EXPOSE 3000

CMD ["npm", "start"]