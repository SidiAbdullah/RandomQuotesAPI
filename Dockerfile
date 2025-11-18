# Use official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["QuotesApi/QuotesApi.csproj", "QuotesApi/"]
RUN dotnet restore "QuotesApi/QuotesApi.csproj"

# Copy all source files
COPY . .
WORKDIR "/src/QuotesApi"

# Publish the app
RUN dotnet publish -c Release -o /app/publish

# Use ASP.NET runtime image for final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose HTTP port
EXPOSE 80

# Entry point
ENTRYPOINT ["dotnet", "QuotesApi.dll"]
