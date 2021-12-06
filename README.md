## Appplication Setting 

|Key|Value | Comment|
|:----|:----|:----|:----|:----|
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



## Azure Table Storage Process


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

## Blob Storage Read Process

|Key|Value|Comments|
|:----|:----|:----|
|ReadFromStorageAndBatchWriteForProcessing|Yes |REQUIRED  :  Reads the File from Blob Container and processes  in|
|FolderName|<FOLDER_NAME>|Folder name of the source location |
|StorageAccount|<STORAGE ACCOUNT NAME>|  Indicates the method in the process to use the API|
|Container| <BLOG CONTAINER NAME>|  Provide a blob container name to read the copied file(s)|
|ColumnHeader| Comma separated file | This is specific for a csv fileFolderName|<FOLDER NAME>|Foldername is added to the config and is automatically  generated  on the 1st file write.|
|DestinationContainer|<BLOG CONTAINER NAME>| Destination container is  where the batched files are written for processing by| |service|
|DestinationfolderName| <FOLDER NAME>| Folder name for the destination  batched files.|
|BatchSize|<BATCH_SIZE_N0> | Number of records to be processed| | |

##File Copy Process

|Key|Value|Comments|
|:----|:----|:----|
|DirectoryName|<DIRECTORY_NAME>|OPTIONAL :Directory name for each user in Azure Storage File Share.  Information can be populated from a data storeFileName|Yes| OPTIONAL : Filename + extension to be written to directory|
|GetFileFromRemoteDataStore|Yes|OPTIONAL :- file can be passed into the database via a  datastore payload request.FileNameProperty|<PROPERTY_NAME>|Name of the property in the JSON payload that contains the file name|
|StorageAccount|<STORAGE ACCOUNT KEY>|Name of the  storage account key in AppSettings.|
|FileShareName|<FILESHARE_NAME>|Required to  connect to the  named Network File Share(NFS) mount.|


##Event Grid Notification Process

|Key|Value|Comments|
|:----|:----|:----|
|SendEventGridMessage|Yes|REQUIRED : To turn on the toggle to start the execution of the process|
|EventUri|<EVENT_KEY_NAME>| Example : "EventURL" :Should be the key name in the app setting|
|KeyCredentials|<KEY_CREDENTIALS>| Example : "EventKeyCredentials" :  Should be the key name in the app setting|
|Subject|<SUBJECT_LINE>|Provide and brief subject line for the Event Grid|
|EventType|<EVENT_TYPE>|Provide the type of event for filtering|
|DataVersion|<DATA_VERSION>|Provide a version example : 1.0|
