# Use the smaller Alpine-based .NET runtime image for production
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use SDK image for build steps
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EventHorizon/EventHorizon.csproj", "EventHorizon/"]
RUN dotnet restore "EventHorizon/EventHorizon.csproj" --verbosity detailed
COPY . .
WORKDIR /src/EventHorizon
RUN dotnet build "EventHorizon.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "EventHorizon.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage with runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventHorizon.dll"]
