@allowed([
  'eastus'
  'westus'
])
param Location string = 'eastus'

@minLength(4)
@maxLength(7)
param Part string

var name='${Part}res'

resource storageaccount 'Microsoft.Storage/storageAccounts@2021-02-01' = {
  name: 'st889${name}'
  location: Location
  kind: 'StorageV2'
  sku: {
    name: 'Standard_LRS'
  }
}
