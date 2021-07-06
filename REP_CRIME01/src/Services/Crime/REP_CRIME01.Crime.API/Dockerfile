#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Crime/REP_CRIME01.Crime.API/REP_CRIME01.Crime.API.csproj", "src/Services/Crime/REP_CRIME01.Crime.API/"]
COPY ["src/Services/Crime/REP_CRIME01.Crime.Application/REP_CRIME01.Crime.Application.csproj", "src/Services/Crime/REP_CRIME01.Crime.Application/"]
COPY ["src/Services/Crime/REP_CRIME01.Crime.Domain/REP_CRIME01.Crime.Domain.csproj", "src/Services/Crime/REP_CRIME01.Crime.Domain/"]
COPY ["src/Services/Crime/REP_CRIME01.Crime.Infrastructure/REP_CRIME01.Crime.Infrastructure.csproj", "src/Services/Crime/REP_CRIME01.Crime.Infrastructure/"]
RUN dotnet restore "src/Services/Crime/REP_CRIME01.Crime.API/REP_CRIME01.Crime.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Crime/REP_CRIME01.Crime.API"
RUN dotnet build "REP_CRIME01.Crime.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "REP_CRIME01.Crime.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "REP_CRIME01.Crime.API.dll"]