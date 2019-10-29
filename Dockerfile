FROM mcr.microsoft.com/dotnet/core/sdk:3.0 as build-env

LABEL maintainer="hanhhn@saigonnewport.com.vn"

COPY . /app

RUN cd /app

CMD ls

RUN dotnet restore

RUN dotnet publish src/Snp.ePort.Api/Snp.ePort.Api.csproj -c Release -o out

WORKDIR /

COPY /app/server/hostip.txt --from=build-env/src/Snp.ePort.Api/out

FROM mcr.microsoft.com/dotnet/core/runtime:3.0

COPY --from=build-env /src/Snp.ePort.Api/out .

EXPOSE 8001

ENTRYPOINT ["dotnet", "Snp.ePort.Api.dll","--launch-profile","Production"]