## Quero criar um container baseado no SDK do .NET 8.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
##Define /src como o diretório de trabalho dentro do container.
WORKDIR /src
##Essa linha pega os arquivos .csproj do diretório onde você está executando o docker build e copia para /src dentro do container.
COPY *.csproj .
##baixa as dependências do projeto.
RUN dotnet restore
##Copia o restante do projeto
COPY . .
##Publica a aplicação gera uma build basicamente para realease
RUN dotnet publish -c Release -o /app
##segunda etapa de imagem para aspnetcore ajuda a ser mais leve
FROM mcr.microsoft.com/dotnet/aspnet:8.0
##define o destino da aplicacao
WORKDIR /app
##copia o resultado da build para app
COPY --from=build /app .
##variavel de ambiente
ENV ASPNETCORE_URLS=http://+:8080
##porta que vai rodar
EXPOSE 8080
#Quando o container iniciar, execute minha aplicação.
ENTRYPOINT ["dotnet", "RabbitIntegrationApi.dll"]