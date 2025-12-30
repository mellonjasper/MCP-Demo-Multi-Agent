# --- Stage 1: Build C# App ---
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj files first to cache dependencies
COPY McpServer/McpServer.csproj McpServer/
COPY Domain/Domain.csproj Domain/

# Restore dependencies
RUN dotnet restore McpServer/McpServer.csproj

# Copy the rest of the source code
COPY . .

# Build and Publish
WORKDIR /src/McpServer
RUN dotnet publish -c Release -o /app/publish

# --- Stage 2: Runtime (Pure .NET - No Node.js needed!) ---
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Copy the compiled app from the build stage
COPY --from=build /app/publish .

# Set environment variable to listen on port 8080 on all interfaces
ENV ASPNETCORE_URLS=http://+:8080

# Expose the port
EXPOSE 8080

# Run the application directly (No supergateway bridge)
ENTRYPOINT ["dotnet", "McpServer.dll"]