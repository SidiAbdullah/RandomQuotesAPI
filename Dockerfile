# ============================
# 1) Build stage
# ============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy all project files
COPY ./QuotesApi ./QuotesApi

# Restore dependencies
RUN dotnet restore ./QuotesApi/QuotesApi.csproj

# Build project
RUN dotnet publish ./QuotesApi/QuotesApi.csproj -c Release -o /publish


# ============================
# 2) Runtime stage
# ============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /publish .

# Render uses PORT environment variable
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

EXPOSE 10000

ENTRYPOINT ["dotnet", "QuotesApi.dll"]
