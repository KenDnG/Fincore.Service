#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FINCORE.SERVICE.CSSESSION/FINCORE.SERVICE.CSSESSION.csproj", "FINCORE.SERVICE.CSSESSION/"]
RUN dotnet restore "FINCORE.SERVICE.CSSESSION/FINCORE.SERVICE.CSSESSION.csproj"
COPY . .
WORKDIR "/src/FINCORE.SERVICE.CSSESSION"
RUN dotnet build "FINCORE.SERVICE.CSSESSION.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FINCORE.SERVICE.CSSESSION.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FINCORE.SERVICE.CSSESSION.dll"]