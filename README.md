PARA FAZER O DEPLOY NO HEROKU - Dentro da raiz:

- dotnet publish -c Release
- docker build -t parkingspot ./bin/release/netcoreapp2.1/publish
- heroku login
- heroku container:login
- docker tag parkingspot registry.heroku.com/webparkingstop/web
- docker push registry.heroku.com/webparkingstop/web
- heroku container:release web -a webparkingstop
