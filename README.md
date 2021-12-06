## Appplication Setting 

|Key|Value | Comment|
|:----|:----|:----|
|AzureWebJobsStorage|<CONNECTION STRING>|RECOMMENDATION :  store in AzureKey Vault.|
|ConfigurationPath|/ ContainerName/Folder |Folder is optional
|ApiKeyName|x-api-key|Will be passed in the header  :  the file name of the config.
|AppName| frontier| This is the name of the Function App. Used in log analytics|
|StorageAcctName|<STORAGE ACCOUNT NAME>|Example  "AzureWebJobsStorage"|
|EventURL|<EVENT_KEY_NAME>| Url should be provided or from Keyvault|
|EventKeyCredentials|<KEY_CREDENTIALS>| Event Grid Key credentials will be retrieved from the Key Vault|


## Function App  Configuration 

> **Note:** The **Configuration** is located in the  FunctionApp  in a **Config** Folder.

|FileName|Description|
|:----|:----|
|43EFE991E8614CFB9EDECF1B0FDED37B.json| Copy file(s) from Storage Account File Share to a Blob Container. Creates batch output file for processing|
|B6B6768321C749B5B52380A16DC120AD.json| Validates the request JSON payload to match schema, and posts to Azure Table|
|B6B6768321C749B5B52380A16DC120AE.json| Free text search on any columns in azure table, validates and AutoMaps the JSON payload response|



## Upload File Process

|Key|Value|Comments|
|:----|:----|:----|
|CreateRecordForAzureTable|SimpleTableSearch|Yes| Indicates the method in the process to use the API|
|PartitionKey|<PROPERTY NAME >|OPTIONAL : Identity the  Field/Key in the JSON payload as a Partition Key|
|ContinueMessage|Yes|OPTIONAL : Return the Request message sent in the API With Partition and Row Key
|QueryField|<SEARCH PROPERTY NAME>|Provide the search property name to be used in the search
|dateformat|<DATETIME>|  date formatTimeZone|<TIMEZONE>| TimeZones
|DefaultResult| <CUSTOM MESSAGE> | OPTIONAL :  No  results return then a default message
|tablename|<AZURE TABLE NAME>| Create table add records
|StorageAccount|<STORAGE ACCOUNT KEY>| Name of the  storage account key in AppSettings.|

