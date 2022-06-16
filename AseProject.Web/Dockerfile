FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["AseProject.Web/AseProject.Web.csproj", "AseProject.Web/"]
RUN dotnet restore "AseProject.Web/AseProject.Web.csproj"
COPY . .
WORKDIR "/src/AseProject.Web"
RUN dotnet build "AseProject.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AseProject.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AseProject.Web.dll"]
