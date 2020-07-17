#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["../GFT.TechnicalTest/GFT.TechnicalTest.csproj", "GFT.TechnicalTest/"]
COPY ["../GFT.TechnicalTest.Data/GFT.TechnicalTest.Data.csproj", "GFT.TechnicalTest.Data/"]
RUN dotnet restore "GFT.TechnicalTest/GFT.TechnicalTest.csproj"
COPY . .
WORKDIR "/src/GFT.TechnicalTest"
RUN dotnet build "GFT.TechnicalTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GFT.TechnicalTest.csproj" -c Release -o /app/publish

RUN dotnet ef database update

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GFT.TechnicalTest.dll"]
