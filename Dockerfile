# Etapa 1: build - compila el proyecto usando el SDK de .NET
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY TeamGitPractice/TeamGitPractice.csproj TeamGitPractice/
RUN dotnet restore TeamGitPractice/TeamGitPractice.csproj

COPY TeamGitPractice/ TeamGitPractice/
RUN dotnet publish TeamGitPractice/TeamGitPractice.csproj -c Release -o /app/publish --no-restore

# Etapa 2: runtime - imagen liviana solo con el runtime de ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "TeamGitPractice.dll"]
