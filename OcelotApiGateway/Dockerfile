# -------- BUILD STAGE --------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# 1. Copy csproj files first (better layer caching)
COPY OcelotApiGateway/OcelotApiGateway.csproj OcelotApiGateway/
COPY Journify.core/Journify.core.csproj Journify.core/
COPY ShareLib/ShareLib.csproj ShareLib/

# 2. Restore dependencies for the gateway
RUN dotnet restore OcelotApiGateway/OcelotApiGateway.csproj

# 3. Copy the remaining source code
COPY OcelotApiGateway/ OcelotApiGateway/
COPY Journify.core/ Journify.core/
COPY ShareLib/ ShareLib/

# 4. Publish the gateway
RUN dotnet publish OcelotApiGateway/OcelotApiGateway.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# -------- RUNTIME STAGE --------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Copy published output
COPY --from=build /app/publish .

# Ensure ocelot configuration and appsettings are present
COPY OcelotApiGateway/ocelot.json ./
COPY OcelotApiGateway/appsettings.json ./
COPY OcelotApiGateway/appsettings.Development.json ./

# Expose gateway port
EXPOSE 8082
ENV ASPNETCORE_URLS=http://+:8082

# Run the gateway
ENTRYPOINT ["dotnet", "OcelotApiGateway.dll"]
