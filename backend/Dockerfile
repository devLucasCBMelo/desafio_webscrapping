# Usar a imagem do .NET SDK como base para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o conteúdo do diretório backend
COPY ./backend /src

# Restaurar as dependências
RUN dotnet restore

# Compilar e publicar a aplicação para produção
RUN dotnet publish -c Release -o /app/out

# Usar a imagem do ASP.NET para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Copiar os arquivos publicados do estágio anterior
COPY --from=build /app/out .

# Expor a porta onde a aplicação vai rodar
EXPOSE 5000

# Definir o comando de entrada para rodar o aplicativo
ENTRYPOINT ["dotnet", "backend.dll"]

