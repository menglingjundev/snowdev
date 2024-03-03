#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Lixil.SNOW.Webservice/Lixil.SNOW.Webservice.csproj", "Lixil.SNOW.Webservice/"]
COPY ["Lixil.Snow.BizLogic/Lixil.Snow.BizLogic.csproj", "Lixil.Snow.BizLogic/"]
COPY ["Lixil.Snow.DataAccess/Lixil.Snow.DataAccess.csproj", "Lixil.Snow.DataAccess/"]
COPY ["Lixil.Snow.DataModel/Lixil.Snow.DataModel.csproj", "Lixil.Snow.DataModel/"]
COPY ["Lixil.Snow.Utilities/Lixil.Snow.Utilities.csproj", "Lixil.Snow.Utilities/"]
RUN dotnet restore "./Lixil.SNOW.Webservice/./Lixil.SNOW.Webservice.csproj"
COPY . .
WORKDIR "/src/Lixil.SNOW.Webservice"
RUN dotnet build "./Lixil.SNOW.Webservice.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Lixil.SNOW.Webservice.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lixil.SNOW.Webservice.dll"]