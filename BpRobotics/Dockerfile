#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BpRobotics/BpRobotics.csproj", "BpRobotics/"]
COPY ["BpRobotics.Data/BpRobotics.Data.csproj", "BpRobotics.Data/"]
COPY ["BpRobotics.Core/BpRobotics.Core.csproj", "BpRobotics.Core/"]
RUN dotnet restore "BpRobotics/BpRobotics.csproj"
COPY . .
WORKDIR "/src/BpRobotics"
RUN dotnet build "BpRobotics.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BpRobotics.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BpRobotics.dll"]