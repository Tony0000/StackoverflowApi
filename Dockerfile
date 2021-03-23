FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /app

COPY /Domain/Domain.csproj /Domain/
COPY /Application/Application.csproj /Application/
COPY /Infrastructure/Infrastructure.csproj /Infrastructure/
COPY /Api/Api.csproj /Api/

RUN dotnet restore /Api/Api.csproj

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Api.dll"]
