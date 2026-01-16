# =========================
# Stage 1: Build stage

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project file and restore dependencies
COPY SafeBoda.Api.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app/publish



# Stage 2: Runtime stage

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published output from build stage
COPY --from=build /app/publish .

# Expose port (ASP.NET Core default)
EXPOSE 8080

# Run the application
ENTRYPOINT ["dotnet", "SafeBoda.Api.dll"]
