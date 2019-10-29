FROM mcr.microsoft.com/dotnet/core/sdk:3.0 as build-env

LABEL maintainer="hanhhn@saigonnewport.com.vn"

COPY / /app

WORKDIR /app

RUN dotnet restore

RUN dotnet publish src/Snp.ePort.Api/Snp.ePort.Api.csproj -c Release -o out

COPY /app/server/hostip.txt --from=build-env/src/Snp.ePort.Api/out/hostip.txt

FROM mcr.microsoft.com/dotnet/core/runtime:3.0

COPY --from=build-env /src/Snp.ePort.Api/out .

EXPOSE 8001

ENTRYPOINT ["dotnet", "Snp.ePort.Api.dll","--launch-profile","Production"]