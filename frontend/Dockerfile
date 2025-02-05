# Usar a imagem como base

FROM node:18-alpine

# Mudar para o diretório de trabalho

WORKDIR /frontend

# Copiar os package.json e package-lock.json para o container

COPY package.json .

COPY package-lock.json .

# Instalar as dependências Node

RUN npm install 

# Copiar o restante dos arquivos da aplicação para o container

COPY . .

# Sinalize que aplicação expõe a porta 3001

EXPOSE 3000

# Configurar os comandos para iniciar a aplicação de acordo com as boas práticas

ENTRYPOINT [ "npm", "run" ]

CMD ["dev"]