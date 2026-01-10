# -------- BUILD STAGE -------- 
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
# We set the WORKDIR to the root of our "virtual" workspace
WORKDIR /Journify

# 1. Copy ALL csproj files using their full relative paths from the root
# This keeps the folder structure identical to your local machine
COPY StepManagmentService/src/StepManagment.api/StepManagment.api.csproj StepManagmentService/src/StepManagment.api/
COPY StepManagmentService/src/StepManagment.service/StepManagment.service.csproj StepManagmentService/src/StepManagment.service/
COPY StepManagmentService/src/StepManagment.infrastructure/StepManagment.infrastructure.csproj StepManagmentService/src/StepManagment.infrastructure/
COPY Journify.core/Journify.core.csproj Journify.core/

# 2. Restore using the path to the API project
RUN dotnet restore StepManagmentService/src/StepManagment.api/StepManagment.api.csproj

# 3. Copy the rest of the source code
COPY StepManagmentService/src/ StepManagmentService/src/
COPY Journify.core/ Journify.core/

# 4. Publish
# Note the path change here to match the new structure
RUN dotnet publish StepManagmentService/src/StepManagment.api/StepManagment.api.csproj \
    -c Release \
    -o /out \
    --no-restore

# -------- RUNTIME STAGE -------- 
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /Journify
# Copy from the /out folder we created in the build stage
COPY --from=build /out .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "StepManagment.api.dll"]