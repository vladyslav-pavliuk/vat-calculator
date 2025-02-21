# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Set environment variable to listen on all interfaces
ENV ASPNETCORE_URLS=http://+:8080

# Build image with SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VatCalculator/VatCalculator.csproj", "VatCalculator/"]
RUN dotnet restore "VatCalculator/VatCalculator.csproj"
COPY . .
WORKDIR "/src/VatCalculator"
RUN dotnet build "VatCalculator.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "VatCalculator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VatCalculator.dll"]
