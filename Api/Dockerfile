FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Api/Api.csproj", "Api/"]
COPY ["LogicaDeNegocio/LogicaDeNegocio.csproj", "LogicaDeNegocio/"]
COPY ["UnidadDeTrabajo/UnidadDeTrabajo.csproj", "UnidadDeTrabajo/"]
COPY ["Repositorio/Repositorio.csproj", "Repositorio/"]
COPY ["Dominio/Dominio.csproj", "Dominio/"]
RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
