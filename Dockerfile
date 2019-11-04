FROM mcr.microsoft.com/dotnet/core/sdk:3.0 as build

LABEL maintainer="hanhhn@saigonnewport.com.vn"

COPY / /source

WORKDIR /source

RUN dotnet restore

WORKDIR /source/src/Snp.Api

RUN dotnet publish -c Release -o out

COPY /server/hostip.txt /source/src/Snp.Api/out/hostip.txt

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime

COPY --from=build /source/src/Snp.Api/out /app

WORKDIR /app

EXPOSE 80

ENTRYPOINT ["dotnet", "Snp.Api.dll"]