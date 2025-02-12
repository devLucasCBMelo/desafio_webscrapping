# Usar a imagem do .NET SDK como base para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definir o diretório de trabalho para o container
WORKDIR /app

# Copiar o conteúdo do diretório 'backend' para o container
# Note que o contexto de build já é ./backend no docker-compose.yml, então 'COPY .' já captura os arquivos necessários
COPY . . 

# Restaurar as dependências
RUN dotnet restore backend.csproj

# Compilar e publicar a aplicação para produção
RUN dotnet publish backend.csproj -c Release -o /app/out

# Usar a imagem do ASP.NET para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Copiar os arquivos publicados do build para o diretório /app
COPY --from=build /app/out .

# Expor a porta onde a aplicação vai rodar
EXPOSE 5000

# Definir o comando de entrada para rodar o aplicativo
ENTRYPOINT ["dotnet", "backend.dll"]
