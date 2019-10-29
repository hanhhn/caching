FROM 3.0.100-bionic as build-env

LABEL maintainer="hanhhn@saigonnewport.com.vn"

WORKDIR /

COPY . /app

RUN cd /app

RUN dotnet restore

RUN dotnet publish src/Snp.ePort.Api/Snp.ePort.Api.csproj -c Release -o out

WORKDIR /

COPY /app/server/hostip.txt --from=build-env/src/Snp.ePort.Api/out

FROM microsoft/dotnet:aspnetcore-runtime

COPY --from=build-env /src/Snp.ePort.Api/out .

EXPOSE 8001

ENTRYPOINT ["dotnet", "Snp.ePort.Api.dll"]