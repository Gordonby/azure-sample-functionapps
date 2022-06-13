# Simple Function App

Just a simple c# Azure Function App to use for test deployments

.NET6 / v4 Functions Runtime

## Routes

| Route | Function Name | Content Type | Description |
| ----- | ------------- | ------------ | ----------- |
| / | BasicHtmlResponse | Html | Hello world |
| /CheckAppSettings | CheckAppSettings | Html | Returns several AppSettings values as Html |
| /api/context | Context | Json | Returns traffic id from AppSettings as well as the default `name` from querystring

## Use it in Bicep

Use this code snippet in Bicep to bind to this repo

```bicep
param repoUrl string = 'https://github.com/Gordonby/SimpleFunctionApp.git'
param repoBranchProduction string = 'main'
resource codeDeploy 'Microsoft.Web/sites/sourcecontrols@2021-01-15' = if (!empty(repoUrl)) {
  parent: functionApp
  name: 'web'
  properties: {
    repoUrl: repoUrl
    branch: repoBranchProduction
    isManualIntegration: true
  }
}

resource functionApp 'Microsoft.Web/sites@2021-02-01' = {
...
}
```
