#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/CrimeFeedback/REP_CRIME01.CrimeFeedback/REP_CRIME01.CrimeFeedback.csproj", "src/Services/CrimeFeedback/REP_CRIME01.CrimeFeedback/"]
COPY ["src/BuildingBlocks/REP_CRIME01.EventBus/REP_CRIME01.EventBus.csproj", "src/BuildingBlocks/REP_CRIME01.EventBus/"]
RUN dotnet restore "src/Services/CrimeFeedback/REP_CRIME01.CrimeFeedback/REP_CRIME01.CrimeFeedback.csproj"
COPY . .
WORKDIR "/src/src/Services/CrimeFeedback/REP_CRIME01.CrimeFeedback"
RUN dotnet build "REP_CRIME01.CrimeFeedback.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "REP_CRIME01.CrimeFeedback.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "REP_CRIME01.CrimeFeedback.dll"]