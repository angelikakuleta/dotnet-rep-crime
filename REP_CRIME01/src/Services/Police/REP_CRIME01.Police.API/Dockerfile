#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Police/REP_CRIME01.Police.API/REP_CRIME01.Police.API.csproj", "src/Services/Police/REP_CRIME01.Police.API/"]
COPY ["src/Services/Police/REP_CRIME01.Police.Application/REP_CRIME01.Police.Application.csproj", "src/Services/Police/REP_CRIME01.Police.Application/"]
COPY ["src/Services/Police/REP_CRIME01.Police.Domain/REP_CRIME01.Police.Domain.csproj", "src/Services/Police/REP_CRIME01.Police.Domain/"]
COPY ["src/Services/Police/REP_CRIME01.Police.Common/REP_CRIME01.Police.Common.csproj", "src/Services/Police/REP_CRIME01.Police.Common/"]
COPY ["src/BuildingBlocks/REP_CRIME01.CQRSResponse/REP_CRIME01.CQRSResponse.csproj", "src/BuildingBlocks/REP_CRIME01.CQRSResponse/"]
COPY ["src/Services/Police/REP_CRIME01.Police.Infrastructure/REP_CRIME01.Police.Infrastructure.csproj", "src/Services/Police/REP_CRIME01.Police.Infrastructure/"]
RUN dotnet restore "src/Services/Police/REP_CRIME01.Police.API/REP_CRIME01.Police.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Police/REP_CRIME01.Police.API"
RUN dotnet build "REP_CRIME01.Police.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "REP_CRIME01.Police.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "REP_CRIME01.Police.API.dll"]