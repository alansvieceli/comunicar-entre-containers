FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Servico02/Servico02.csproj", "Servico02/"]
RUN dotnet restore "Servico02/Servico02.csproj"
COPY . .
WORKDIR "/src/Servico02"
RUN dotnet build "Servico02.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Servico02.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Servico02.dll"]