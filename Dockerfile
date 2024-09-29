FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/AudioInsight.API/AudioInsight.API.csproj", "src/AudioInsight.API/"]
COPY ["contracts/AudioInsight.Contracts/AudioInsight.Contracts.csproj", "contracts/AudioInsight.Contracts/"]
COPY ["src/AudioInsight.Application/AudioInsight.Application.csproj", "src/AudioInsight.Application/"]
COPY ["src/AudioInsight.Domain/AudioInsight.Domain.csproj", "src/AudioInsight.Domain/"]
COPY ["src/AudioInsight.Infrastructure/AudioInsight.Infrastructure.csproj", "src/AudioInsight.Infrastructure/"]
COPY ["src/AudioInsight.DataContext/AudioInsight.DataContext.csproj", "src/AudioInsight.DataContext/"]
RUN dotnet restore "./src/AudioInsight.API/AudioInsight.API.csproj"
COPY . .
WORKDIR "/src/src/AudioInsight.API"
RUN dotnet build "./AudioInsight.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AudioInsight.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AudioInsight.API.dll"]