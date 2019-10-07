FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Ocean.Api/Ocean.Api.csproj", "src/Ocean.Api/"]
RUN dotnet restore "src/Ocean.Api/Ocean.Api.csproj"
COPY . .
WORKDIR "/src/src/Ocean.Api"
RUN dotnet build "Ocean.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ocean.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ocean.Api.dll"]