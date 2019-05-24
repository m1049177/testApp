FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY *.csproj ./
RUN dotnet restore
 
COPY . ./
RUN dotnet publish -c Release -o /app

FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app

ENV http_proxy http://0.0.0.0:5000
COPY --from=build-env /app/ .
ENTRYPOINT ["dotnet","testApp.dll"]
