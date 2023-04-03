#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FINCORE.SERVICE.BPKB/FINCORE.SERVICE.BPKB.csproj", "FINCORE.SERVICE.BPKB/"]
RUN dotnet restore "FINCORE.SERVICE.BPKB/FINCORE.SERVICE.BPKB.csproj"
COPY . .
WORKDIR "/src/FINCORE.SERVICE.BPKB"
RUN dotnet build "FINCORE.SERVICE.BPKB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FINCORE.SERVICE.BPKB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FINCORE.SERVICE.BPKB.dll"]