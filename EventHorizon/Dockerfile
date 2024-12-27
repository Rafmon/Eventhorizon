FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

ARG PLATFORM
COPY ./output/${PLATFORM}/* .

ENTRYPOINT ["dotnet", "EventHorizon.dll"]