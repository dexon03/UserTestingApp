FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UserTestingAPI/UserTestingAPI.csproj", "UserTestingAPI/"]
RUN dotnet restore "UserTestingAPI/UserTestingAPI.csproj"
COPY . .
WORKDIR "/src/UserTestingAPI"
RUN dotnet build "UserTestingAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserTestingAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserTestingAPI.dll"]
