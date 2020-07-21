
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.6-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/core/sdk:3.1.6-buster AS build
WORKDIR /src

RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/core/sdk:3.1.6-buster AS build
WORKDIR /src
COPY ["../Restaurant/Restaurant.csproj", "Restaurant/"]
COPY ["../Restaurant.Data/Restaurant.Data.csproj", "Restaurant.Data/"]
RUN dotnet restore "Restaurant/Restaurant.csproj"
COPY . .
WORKDIR "/src/Restaurant"
RUN dotnet build "Restaurant.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Restaurant.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Restaurant.dll"]
