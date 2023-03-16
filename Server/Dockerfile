#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
#EXPOSE 5432
#
#FROM postgres:14.6
#RUN apt-get update && apt-get install -q -y postgresql-14.6 postgresql-client-14.6 postgresql-contrib-14.6 postgresql-client-common postgresql-common
#RUN /etc/init.d/postgresql start
#
#RUN su -c "psql -c \"ALTER USER postgres PASSWORD 'postgres';\"" postgr

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/Server.csproj", "Server/"]
RUN dotnet restore "Server/Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Server.dll"]