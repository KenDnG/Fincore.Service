#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FINCORE.SERVICE.NPP/FINCORE.SERVICE.NPP.csproj", "FINCORE.SERVICE.NPP/"]
RUN dotnet restore "FINCORE.SERVICE.NPP/FINCORE.SERVICE.NPP.csproj"
COPY . .
WORKDIR "/src/FINCORE.SERVICE.NPP"
RUN dotnet build "FINCORE.SERVICE.NPP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FINCORE.SERVICE.NPP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FINCORE.SERVICE.NPP.dll"]