FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /src
COPY ["RunningBackgroundTasks/RunningBackgroundTasks.csproj", "RunningBackgroundTasks/"]
RUN dotnet restore "./RunningBackgroundTasks/RunningBackgroundTasks.csproj"
COPY . .
WORKDIR "/src/RunningBackgroundTasks"
RUN dotnet build "./RunningBackgroundTasks.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RunningBackgroundTasks.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RunningBackgroundTasks.dll"]