#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StravaClone.Web/StravaClone.Web.csproj", "StravaClone.Web/"]
COPY ["StravaClone.DataService/StravaClone.DataService.csproj", "StravaClone.DataService/"]
COPY ["StravaClone.Entities/StravaClone.Entities.csproj", "StravaClone.Entities/"]
RUN dotnet restore "StravaClone.Web/StravaClone.Web.csproj"
COPY . .
WORKDIR "/src/StravaClone.Web"
RUN dotnet build "StravaClone.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "StravaClone.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StravaClone.Web.dll"]