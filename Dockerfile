# Etapa 1: build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copia arquivos do projeto e restaura dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante dos arquivos e faz o build
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: runtime da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copia arquivos publicados da etapa anterior
COPY --from=build /app/out ./

# Expõe a porta (ex: 80 para APIs)
EXPOSE 80

# Define o comando de inicialização
ENTRYPOINT ["dotnet", "GameResultsApi.dll"]
