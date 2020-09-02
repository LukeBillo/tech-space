# Setup
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN curl --silent --location https://deb.nodesource.com/setup_10.x | bash -
RUN apt-get install --yes nodejs

COPY . .
RUN dotnet publish -c release -o /app

# Run the app
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
RUN curl --silent --location https://deb.nodesource.com/setup_10.x | bash -
RUN apt-get install --yes nodejs

COPY --from=build /app .

ENV ASPNETCORE_ENVIRONMENT="Production"
ENTRYPOINT ["dotnet", "TechSpace.dll"]