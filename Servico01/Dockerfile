FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Servico01/Servico01.csproj", "Servico01/"]
RUN dotnet restore "Servico01/Servico01.csproj"
COPY . .
WORKDIR "/src/Servico01"
RUN dotnet build "Servico01.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Servico01.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Servico01.dll"]