#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Web/REP_CRIME01.CrimeReportWeb/REP_CRIME01.CrimeReportWeb.csproj", "src/Web/REP_CRIME01.CrimeReportWeb/"]
COPY ["src/Services/Crime/REP_CRIME01.Crime.Common/REP_CRIME01.Crime.Common.csproj", "src/Services/Crime/REP_CRIME01.Crime.Common/"]
RUN dotnet restore "src/Web/REP_CRIME01.CrimeReportWeb/REP_CRIME01.CrimeReportWeb.csproj"
COPY . .
WORKDIR "/src/src/Web/REP_CRIME01.CrimeReportWeb"
RUN dotnet build "REP_CRIME01.CrimeReportWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "REP_CRIME01.CrimeReportWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "REP_CRIME01.CrimeReportWeb.dll"]
