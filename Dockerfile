# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and all project files
COPY RecipeShare.sln ./
COPY RecipeShare/RecipeShare.csproj RecipeShare/
COPY ClassLibrary/ClassLibrary.csproj ClassLibrary/
COPY RecipeShare.Benchmark/RecipeShare.Benchmark.csproj RecipeShare.Benchmark/
COPY RecipeShare.Tests/RecipeShare.Tests.csproj RecipeShare.Tests/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the source code
COPY . .

# Publish the main app (RecipeShare)
WORKDIR /src/RecipeShare
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Expose the port your app runs on
EXPOSE 7069

# Copy published output from build stage
COPY --from=build /app/publish .

# Run the app
ENTRYPOINT ["dotnet", "RecipeShare.dll"]
