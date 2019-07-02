FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Parkingspot/Parkingspot.csproj Parkingspot/
RUN dotnet restore Parkingspot/Parkingspot.csproj
COPY . .
WORKDIR /src/Parkingspot
RUN dotnet build Parkingspot.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Parkingspot.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Parkingspot.dll"]