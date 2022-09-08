$cert = New-SelfSignedCertificate -CertStoreLocation Cert:\LocalMachine\my -dns stocks.io
$pwd = ConvertTo-SecureString -String "pa55w0rd!" -Force -AsPlainText
$certpath = "Cert:\LocalMachine\my\$($cert.Thumbprint)"

Export-PfxCertificate -Cert $certpath -FilePath C:\Workspace_microservice\MicroservicesDemo\backend\certs\backend.pfx -Password $pwd


# setup UserSecrets
# dotnet user-secrets set "CertPassword" "pa55w0rd!"

