#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/SatelliteOrchestrator/SatelliteOrchestrator.API/SatelliteOrchestrator.API.csproj", "src/Services/SatelliteOrchestrator/SatelliteOrchestrator.API/"]
COPY ["src/BuildingBlocks/Eventbus.Messages/Eventbus.Messages.csproj", "src/BuildingBlocks/Eventbus.Messages/"]
RUN dotnet restore "src/Services/SatelliteOrchestrator/SatelliteOrchestrator.API/SatelliteOrchestrator.API.csproj"
COPY . .
WORKDIR "/src/src/Services/SatelliteOrchestrator/SatelliteOrchestrator.API"
RUN dotnet build "SatelliteOrchestrator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SatelliteOrchestrator.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SatelliteOrchestrator.API.dll"]