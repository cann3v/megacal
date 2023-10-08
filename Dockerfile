#ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# SDK for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["megacal.csproj", "megacal/"]
RUN dotnet restore "megacal/megacal.csproj"
COPY . megacal/
WORKDIR "/src/megacal"
RUN dotnet build "megacal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "megacal.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "megacal.dll"]
