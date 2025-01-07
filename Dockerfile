FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS Base

COPY ./app/api ./app
COPY ./app/web ./app/wwwroot

WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "AspirePoc.UI.Api.dll"]
