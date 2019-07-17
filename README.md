PARA FAZER O DEPLOY NO HEROKU - Dentro da raiz:

- dotnet publish -c Release
- verificar se o Dockerfile está dentro da pasta ./bin/release/netcoreapp2.1/publish (Detalhes abaixo)
- docker build -t parkingspot ./bin/release/netcoreapp2.1/publish
- heroku login
- heroku container:login
- docker tag parkingspot registry.heroku.com/parkingspot-back/web
- docker push registry.heroku.com/parkingspot-back/web
- heroku container:release web -a parkingspot-back

Dockerfile do publish:
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Parkingspot.dll
