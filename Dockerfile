FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-image

WORKDIR /home/app

COPY ./*.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done

RUN dotnet restore

COPY . .

RUN dotnet publish ./TeleDocServer/TeleDocServer.csproj -o /publish/

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-focal

WORKDIR /publish

COPY --from=build-image /publish .

ENV ASPNETCORE_URLS="http://0.0.0.0:5000"

ENTRYPOINT ["dotnet", "TeleDocServer.dll"]