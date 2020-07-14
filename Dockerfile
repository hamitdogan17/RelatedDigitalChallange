FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/RelatedChallange.Web/RelatedChallange.Web.csproj", "src/RelatedChallange.Web/"]
COPY ["src/RelatedChallange.Application/RelatedChallange.Application.csproj", "src/RelatedChallange.Application/"]
COPY ["src/RelatedChallange.Core/RelatedChallange.Core.csproj", "src/RelatedChallange.Core/"]
COPY ["src/RelatedChallange.Infrastructure/RelatedChallange.Infrastructure.csproj", "src/RelatedChallange.Infrastructure/"]
RUN dotnet restore "src/RelatedChallange.Web/RelatedChallange.Web.csproj"
COPY . .
WORKDIR "/src/src/RelatedChallange.Web"
RUN dotnet build "RelatedChallange.Web.csproj" -c Release -o /app/build
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_10.x | bash - && \
    apt-get install -y build-essential nodejs
    
FROM build AS publish
RUN dotnet publish "RelatedChallange.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RelatedChallange.Web.dll"]
