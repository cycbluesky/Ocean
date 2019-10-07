FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Ocean.Web/Ocean.Web.csproj", "Ocean.Web/"]
RUN dotnet restore "Ocean.Web/Ocean.Web.csproj"
COPY . .
WORKDIR "/src/Ocean.Web"
RUN dotnet build "Ocean.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ocean.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ocean.Web.dll"]