# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy csproj and restore
COPY src/Gobi.Consulting/*.csproj ./src/Gobi.Consulting/
RUN dotnet restore ./src/Gobi.Consulting/Gobi.Consulting.csproj

# Copy everything else and build
COPY src/Gobi.Consulting/. ./src/Gobi.Consulting/
WORKDIR /source/src/Gobi.Consulting
RUN dotnet publish -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

# Expose port
EXPOSE 8080

# Set environment variable for ASP.NET Core
ENV ASPNETCORE_URLS=http://+:8080

# Run the app
ENTRYPOINT ["dotnet", "Gobi.Consulting.dll"]

