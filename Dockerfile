# ===========================
# Build Stage
# ===========================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# COPY *.csproj ./

COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o /out

# ===========================
# Runtime Stage
# ===========================
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /out .

ENTRYPOINT ["dotnet", "WeatherApp.dll"]
