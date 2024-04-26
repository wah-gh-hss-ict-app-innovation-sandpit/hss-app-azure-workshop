#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WhereIsPatient.Web/Server/WhereIsPatient.Web.Server.csproj", "WhereIsPatient.Web/Server/"]
COPY ["WhereIsPatient.DB/WhereIsPatient.DB.csproj", "WhereIsPatient.DB/"]
COPY ["WhereIsPatient.Web/Client/WhereIsPatient.Web.Client.csproj", "WhereIsPatient.Web/Client/"]
COPY ["WhereIsPatient.Web/Shared/WhereIsPatient.Web.Shared.csproj", "WhereIsPatient.Web/Shared/"]
RUN dotnet restore "WhereIsPatient.Web/Server/WhereIsPatient.Web.Server.csproj"
COPY . .
WORKDIR "/src/WhereIsPatient.Web/Server"
RUN dotnet build "WhereIsPatient.Web.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WhereIsPatient.Web.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WhereIsPatient.Web.Server.dll"]