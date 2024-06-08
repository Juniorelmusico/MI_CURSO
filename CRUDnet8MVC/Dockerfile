# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files to the container
COPY ["CRUDnet8MVC/CRUDnet8MVC.csproj", "CRUDnet8MVC/"]
RUN dotnet restore "CRUDnet8MVC/CRUDnet8MVC.csproj"

# Copy the remaining files and build the project
COPY . .
WORKDIR "/src/CRUDnet8MVC"
RUN dotnet build "CRUDnet8MVC.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "CRUDnet8MVC.csproj" -c Release -o /app/publish

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CRUDnet8MVC.dll"]
