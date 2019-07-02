FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
COPY . .

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src

CMD ASPNETCORE_URL=http://*:$PORT dotnet Parkingstop.dll