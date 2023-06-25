$jsonConfigPath = "config.json"
$jsonData = Get-Content $jsonConfigPath -Raw
$jsonConfig = ConvertFrom-Json $jsonData
$useCosmosDB = $true
$jsonConfig.DataStoreSettings.AzureStorageInfo.IsUsingCosmosDb = [System.Convert]::ToBoolean($useCosmosDB)
$jsonConfig.MasterElectionSettings.UseDataStore = [System.Convert]::ToBoolean($useCosmosDB)

$jsonData = ConvertTo-Json $jsonConfig -Depth 10
# $jsonData | Out-File $jsonConfigPath
echo $jsonData