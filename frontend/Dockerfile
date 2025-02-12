# Usar a imagem como base
FROM node:18-alpine

# Mudar para o diretório de trabalho
WORKDIR /frontend

# Copiar os package.json e package-lock.json para o container
COPY ./frontend/package.json .
COPY ./frontend/package-lock.json .

# Instalar as dependências Node
RUN npm install 

# Copiar o restante dos arquivos da aplicação para o container
COPY ./frontend . 

# Sinalize que aplicação expõe a porta 3000
EXPOSE 3000

# Configurar os comandos para iniciar a aplicação de acordo com as boas práticas
CMD ["npm", "run", "dev"]

