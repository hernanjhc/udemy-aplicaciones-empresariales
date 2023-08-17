FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/Pacagroup.Eccomerce.Services.WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /src/Pacagroup.Eccomerce.Services.WebApi/out ./

ENTRYPOINT ["dotnet", "Pacagroup.Eccomerce.Services.WebApi.dll"]