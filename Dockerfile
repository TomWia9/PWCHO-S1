# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the source code into the container
COPY . .

# Build the application
RUN dotnet restore && \
    dotnet build -c Release && \
    dotnet publish -c Release -o out

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy the published application from the previous stage
COPY --from=build /app/out .

# Set environment variables
ENV ASPNETCORE_URLS=http://*:80
ENV ASPNETCORE_ENVIRONMENT=Production

# Expose the port the application is listening on
EXPOSE 80/tcp

# Define a healthcheck
HEALTHCHECK --interval=5s --timeout=3s \
  CMD curl --fail http://localhost:80/healthcheck || exit 1

# Set author information
LABEL author="[Tomasz Wiatrowski]"

# Start the application
ENTRYPOINT ["dotnet", "Serwer.dll"]
