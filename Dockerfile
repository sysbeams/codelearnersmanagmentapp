FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Build stage for the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /

# Copy solution files
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Host/WebApi.csproj", "Host/"]
RUN dotnet restore "Host/WebApi.csproj"
COPY . ./

WORKDIR /Host
RUN dotnet build --no-restore "WebApi.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
WORKDIR /Host
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish

# Create the final runtime image
FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:8080
COPY --from=publish /app/publish .
EXPOSE 8080/tcp
ENTRYPOINT ["dotnet", "WebApi.dll"]
