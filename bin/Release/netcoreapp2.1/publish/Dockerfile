FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app
RUN dotnet publish -c Release -o out
FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "Parkingstop.dll"]