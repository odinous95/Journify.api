# -------- BUILD STAGE --------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /Journify

# 1. Copy csproj files first (better layer caching)
COPY StepManagmentService/src/StepManagment.api/StepManagment.api.csproj StepManagmentService/src/StepManagment.api/
COPY StepManagmentService/src/StepManagment.service/StepManagment.service.csproj StepManagmentService/src/StepManagment.service/
COPY StepManagmentService/src/StepManagment.infrastructure/StepManagment.infrastructure.csproj StepManagmentService/src/StepManagment.infrastructure/
COPY Journify.core/Journify.core.csproj Journify.core/
COPY ShareLib/ShareLib.csproj ShareLib/

# 2. Restore dependencies
RUN dotnet restore StepManagmentService/src/StepManagment.api/StepManagment.api.csproj

# 3. Copy the remaining source code
COPY StepManagmentService/src/ StepManagmentService/src/
COPY Journify.core/ Journify.core/
COPY ShareLib/ ShareLib/

# 4. Publish the API
RUN dotnet publish StepManagmentService/src/StepManagment.api/StepManagment.api.csproj \
    -c Release \
    -o /out \
    --no-restore

# -------- RUNTIME STAGE --------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /Journify

COPY --from=build /out .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "StepManagment.api.dll"]
