#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CK.Central.API.CMS/CK.Central.API.CMS.csproj", "CK.Central.API.CMS/"]
COPY ["CK.Central.Backend.ServiceDefaults/CK.Central.Backend.ServiceDefaults.csproj", "CK.Central.Backend.ServiceDefaults/"]
COPY ["CK.Central.Core.CMS/CK.Central.Core.CMS.csproj", "CK.Central.Core.CMS/"]
COPY ["CK.Central.Core.Domain/CK.Central.Core.Domain.csproj", "CK.Central.Core.Domain/"]
COPY ["CK.Central.Core/CK.Central.Core.csproj", "CK.Central.Core/"]
RUN dotnet restore "./CK.Central.API.CMS/CK.Central.API.CMS.csproj"
COPY . .
WORKDIR "/src/CK.Central.API.CMS"
RUN dotnet build "./CK.Central.API.CMS.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CK.Central.API.CMS.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CK.Central.API.CMS.dll"]