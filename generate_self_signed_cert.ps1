# Source: https://stackoverflow.com/a/62060315
# Generate self-signed certificate to be used by frontend.
# When using localhost - backend cannot see the frontend from within the docker-compose'd network.
# You have to run this script as Administrator (open Powershell by right click -> Run as Administrator).

$ErrorActionPreference = "Stop"

$rootCN = "MicroservicesDemooRootCert"
$frontendCNs = "frontend", "localhost"
$backendCNs = "backend", "localhost"

$alreadyExistingCertsRoot = Get-ChildItem -Path Cert:\LocalMachine\My -Recurse | Where-Object {$_.Subject -eq "CN=$rootCN"}
$alreadyExistingCertsfrontend = Get-ChildItem -Path Cert:\LocalMachine\My -Recurse | Where-Object {$_.Subject -eq ("CN={0}" -f $frontendCNs[0])}
$alreadyExistingCertsbackend = Get-ChildItem -Path Cert:\LocalMachine\My -Recurse | Where-Object {$_.Subject -eq ("CN={0}" -f $backendCNs[0])}

if ($alreadyExistingCertsRoot.Count -eq 1) {
    Write-Output "Skipping creating Root CA certificate as it already exists."
    $testRootCA = [Microsoft.CertificateServices.Commands.Certificate] $alreadyExistingCertsRoot[0]
} else {
    $testRootCA = New-SelfSignedCertificate -Subject $rootCN -KeyUsageProperty Sign -KeyUsage CertSign -CertStoreLocation Cert:\LocalMachine\My
}

if ($alreadyExistingCertsfrontend.Count -eq 1) {
    Write-Output "Skipping creating frontend certificate as it already exists."
    $frontendCert = [Microsoft.CertificateServices.Commands.Certificate] $alreadyExistingCertsfrontend[0]
} else {
    # Create a SAN cert for both frontend and localhost.
    $frontendCert = New-SelfSignedCertificate -DnsName $frontendCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
}

if ($alreadyExistingCertsbackend.Count -eq 1) {
    Write-Output "Skipping creating backend certificate as it already exists."
    $backendCert = [Microsoft.CertificateServices.Commands.Certificate] $alreadyExistingCertsbackend[0]
} else {
    # Create a SAN cert for both backend and localhost.
    $backendCert = New-SelfSignedCertificate -DnsName $backendCNs -Signer $testRootCA -CertStoreLocation Cert:\LocalMachine\My
}

# Export it for docker container to pick up later.
$password = ConvertTo-SecureString -String "password" -Force -AsPlainText

$rootCertPathPfx = "certs"
$frontendCertPath = "frontend/certs"
$backendCertPath = "backend/certs"

[System.IO.Directory]::CreateDirectory($rootCertPathPfx) | Out-Null
[System.IO.Directory]::CreateDirectory($frontendCertPath) | Out-Null
[System.IO.Directory]::CreateDirectory($backendCertPath) | Out-Null

Export-PfxCertificate -Cert $testRootCA -FilePath "$rootCertPathPfx/aspnetapp-root-cert.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $frontendCert -FilePath "$frontendCertPath/aspnetapp-frontend.pfx" -Password $password | Out-Null
Export-PfxCertificate -Cert $backendCert -FilePath "$backendCertPath/aspnetapp-backend.pfx" -Password $password | Out-Null

# Export .cer to be converted to .crt to be trusted within the Docker container.
$rootCertPathCer = "certs/aspnetapp-root-cert.cer"
Export-Certificate -Cert $testRootCA -FilePath $rootCertPathCer -Type CERT | Out-Null

# Trust it on your host machine.
$store = New-Object System.Security.Cryptography.X509Certificates.X509Store "Root","LocalMachine"
$store.Open("ReadWrite")

$rootCertAlreadyTrusted = ($store.Certificates | Where-Object {$_.Subject -eq "CN=$rootCN"} | Measure-Object).Count -eq 1

if ($rootCertAlreadyTrusted -eq $false) {
    Write-Output "Adding the root CA certificate to the trust store."
    $store.Add($testRootCA)
}

$store.Close()