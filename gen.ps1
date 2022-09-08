dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\backend.pfx -p pa55w0rd!
dotnet dev-certs https --trust

docker run --rm -it -p 5800:80 -p 5803:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=5803 -e ASPNETCORE_Kestrel__Certificates__Default__Password="pa55w0rd!" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/backend.pfx -v $env:USERPROFILE\.aspnet\https:/https/ backend:latest


dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\frontend.pfx -p pa55w0rd!
dotnet dev-certs https --trust

docker run --rm -it -p 5900:80 -p 5903:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=5903 -e ASPNETCORE_Kestrel__Certificates__Default__Password="pa55w0rd!" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/frontend.pfx -v $env:USERPROFILE\.aspnet\https:/https/ frontend:latest
