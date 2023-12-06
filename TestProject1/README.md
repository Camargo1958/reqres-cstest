# Testes de API em C# gerados automaticamente pelo DeepSeek Coder

Install plugins:
- dotnet
- C#
- C# Dev Kit
- .NET Install Tool
- .NET Core Tools
- .NET Core Test Explorer
- Nuget Package Manager

Use (Packages):
- Newtonsoft.Json v 13.0.3
- RestSharp v 110.2.0
- Xunit v 2.4.1
- NUnit v 3.14.0
- Microsoft.NET.Test.Sdk v 17.5.0
- Allure.NUnit v 2.10.0

Instalação do Allure (PoweShell):
- Scoop
PS C:\Users\Aldrovando> Set-ExecutionPolicy RemoteSigned -scope CurrentUser                                             
PS C:\Users\Aldrovando> iex (new-object net.webclient).downloadstring('https://get.scoop.sh')                           
Initializing...
Downloading ...
Creating shim...
Adding ~\scoop\shims to your path.
Scoop was installed successfully!
Type 'scoop help' for instructions.

- Allure
PS C:\Users\Aldrovando> scoop install allure
Installing 'allure' (2.24.1) [64bit] from main bucket
allure-2.24.1.zip (20,2 MB) [=================================================================================] 100%
Checking hash of allure-2.24.1.zip ... ok.
Extracting allure-2.24.1.zip ... done.
Linking ~\scoop\apps\allure\current => ~\scoop\apps\allure\2.24.1
Creating shim for 'allure'.
'allure' (2.24.1) was installed successfully!
PS C:\Users\Aldrovando> scoop update allure
allure: 2.24.1 (latest version)
Latest versions for all apps are installed! For more information try 'scoop status'


Prompts (DeepSeek Coder):

1- write restsharp test classes and methods for the following openapi json data {petstore swagger in https://petstore.swagger.io/v2/swagger.json}... (PetstoreTests.cs)

2-Generate restsharp test classes and methods for get request in https://reqres.in/api/users?page=2 and for the following response [json] ....(ReqresTest1, ReqresTest2.cs)

3-Generate restsharp test classes and methods for post request in https://reqres.in/api/users, for the following request and response json specifications. The expected status code must be 201. request: {
    "name": "morpheus",
    "job": "leader"
}, response: {
    "name": "morpheus",
    "job": "leader",
    "id": "860",
    "createdAt": "2023-11-17T16:59:57.040Z"
}