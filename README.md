## Architeture diagram 

![image](https://user-images.githubusercontent.com/15838780/212723226-6f61e674-ef74-4f62-b8ab-982cd22b590c.png)

## How to install  ACI for SFTP ##

https://docs.microsoft.com/en-us/samples/azure-samples/sftp-creation-template/sftp-on-azure

## Appplication Setting 

|Key|Value | Comment|
|:----|:----|:----|
|AzureWebJobsStorage|[CONNECTION STRING]|RECOMMENDATION :  store in AzureKey Vault.|
|ConfigurationPath| [CONFIGURATION FOLDER PATH] |Folder is optional
|ApiKeyName|[API KEY NAME]|Will be passed in the header  :  the file name of the config.
|AppName| [APPLICATION NAME]| This is the name of the Function App. Used in log analytics|
|StorageAcctName|[STORAGE ACCOUNT NAME]|Example  "AzureWebJobsStorage"|
|TimerInterval|[TIMER_INTERVAL]|Example  "0 */1 * * * *" 1 MIN|

## Function App  Configuration 

> **Note:** The **Configuration** is located in the  FunctionApp  in a **Config** Folder.

|FileName|Description|
|:----|:----|
|43EFE991E8614CFB9EDECF1B0FDED37A.json| Upload CSV files --> Add to datastore|
|43EFE991E8614CFB9EDECF1B0FDED37B.json| Update an existing record|
|43EFE991E8614CFB9EDECF1B0FDED37C.json| Search Records in datastore|
|43EFE991E8614CFB9EDECF1B0FDED37D.json| Create a new record in datastore|
|3FB620B0E0FD4E8F93C9E4D839D00E1C.json| Uplad a CSV and create a batch|

  ## Products

|products|links|Comments|
|:----|:----|:----|
|Azure Getting Started |https://azure.microsoft.com/en-us/free/| Create free account + $200 in Credit|
|Azure Storage Explorer|https://azure.microsoft.com/en-us/features/storage-explorer/#features|useful view and query data in azure table storage|
|Postman|https://www.postman.com/downloads/|Postman supports the Web or Desktop Version|
|VsCode| https://visualstudio.microsoft.com/downloads/ |  Required extensions. Azure Functions, Azure Account
|VS Studio Community Edition |https://visualstudio.microsoft.com/downloads/| Recommended. Nice intergration with Azure. software is free.

  
  
  ## Contact
  
For questions related to this project, can be reached via email :- support@xenhey.com
