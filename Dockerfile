FROM mcr.microsoft.com/dotnet/core/sdk:3.0 as build-env

LABEL maintainer="hanhhn@saigonnewport.com.vn"

COPY / /src

WORKDIR /src

RUN dotnet restore

RUN dotnet publish src/Snp.ePort.Api/Snp.ePort.Api.csproj -c Release -o out

COPY /server/hostip.txt --from=build-env/src/Snp.ePort.Api/out/hostip.txt

FROM mcr.microsoft.com/dotnet/core/runtime:3.0

COPY --from=build-env /src/Snp.ePort.Api/out /app

WORKDIR /app

EXPOSE 8001

ENTRYPOINT ["dotnet", "Snp.ePort.Api.dll","--launch-profile","Production"]