FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /feapp

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o feout

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /feapp
COPY --from=build-env /feapp/feout .
ENTRYPOINT ["dotnet", "SpacePark.FrontEnd.dll"]
