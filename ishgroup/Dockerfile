FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ishgroup/ishgroup.csproj", "ishgroup/"]
RUN dotnet restore "ishgroup/ishgroup.csproj"
COPY . .
WORKDIR "/src/ishgroup"
RUN dotnet build "ishgroup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ishgroup.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ishgroup.dll"]
