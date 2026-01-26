# -------- BUILD STAGE --------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /Journify

# 1. Copy csproj files first (better layer caching)
COPY UserManagmentService/src/UserManagment.api/UserManagment.api.csproj UserManagmentService/src/UserManagment.api/
COPY UserManagmentService/src/UserManagment.service/UserManagment.service.csproj UserManagmentService/src/UserManagment.service/
COPY UserManagmentService/src/UserManagment.infrastructure/UserManagment.infrastructure.csproj UserManagmentService/src/UserManagment.infrastructure/
COPY Journify.core/Journify.core.csproj Journify.core/
COPY ShareLib/ShareLib.csproj ShareLib/

# 2. Restore dependencies
RUN dotnet restore UserManagmentService/src/UserManagment.api/UserManagment.api.csproj

# 3. Copy the remaining source code
COPY UserManagmentService/src/ UserManagmentService/src/
COPY Journify.core/ Journify.core/
COPY ShareLib/ ShareLib/

# 4. Publish the API
RUN dotnet publish UserManagmentService/src/UserManagment.api/UserManagment.api.csproj \
    -c Release \
    -o /out \
    --no-restore

# -------- RUNTIME STAGE --------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /Journify

COPY --from=build /out .

EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:8081

ENTRYPOINT ["dotnet", "UserManagment.api.dll"]
