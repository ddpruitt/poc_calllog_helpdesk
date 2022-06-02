#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PoC.OdataCore2022v1/PoC.OdataCore2022v1.csproj", "PoC.OdataCore2022v1/"]
RUN dotnet restore "PoC.OdataCore2022v1/PoC.OdataCore2022v1.csproj"
COPY . .
WORKDIR "/src/PoC.OdataCore2022v1"
RUN dotnet build "PoC.OdataCore2022v1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PoC.OdataCore2022v1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PoC.OdataCore2022v1.dll"]