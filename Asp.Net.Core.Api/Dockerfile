#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Asp.Net.Core.Api/Asp.Net.Core.Api.csproj", "Asp.Net.Core.Api/"]
COPY ["Asp.Net.Core.Business/Asp.Net.Core.Business.csproj", "Asp.Net.Core.Business/"]
COPY ["Asp.Net.Core.DataContext/Asp.Net.Core.DataContext.csproj", "Asp.Net.Core.DataContext/"]
COPY ["Asp.Net.Core.DataModel/Asp.Net.Core.DataModel.csproj", "Asp.Net.Core.DataModel/"]
RUN dotnet restore "Asp.Net.Core.Api/Asp.Net.Core.Api.csproj"
COPY . .
WORKDIR "/src/Asp.Net.Core.Api"
RUN dotnet build "Asp.Net.Core.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Asp.Net.Core.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Asp.Net.Core.Api.dll"]