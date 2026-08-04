# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY ["BiketrackerFrontend.csproj", "./"]

RUN dotnet restore "BiketrackerFrontend.csproj"

COPY . .

RUN dotnet publish "BiketrackerFrontend.csproj" \
    -c Release \
    -o /app/publish


# Serve stage
FROM nginx:alpine AS final

COPY --from=build /app/publish/wwwroot /usr/share/nginx/html

EXPOSE 80

ENTRYPOINT ["nginx", "-g", "daemon off;"]