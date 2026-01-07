# -------- BUILD STAGE -------- 
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src  
# Copy csproj files first (for Docker cache) 
COPY src/Journify.api/Journify.api.csproj src/Journify.api/
COPY src/Journify.service/Journify.service.csproj src/Journify.service/
COPY src/Journify.infrastructure/Journify.infrastructure.csproj src/Journify.infrastructure/
COPY src/Journify.core/Journify.core.csproj src/Journify.core/
# Restore dependencies
RUN dotnet restore src/Journify.api/Journify.api.csproj
# Copy everything else 
COPY src/ ./src/
# Publish
RUN dotnet publish src/Journify.api/Journify.api.csproj \
-c Release \
-o /app/publish \
--no-restore
# -------- RUNTIME STAGE -------- 
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Journify.api.dll"]