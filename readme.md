# EbaySharp: A .NET wrapper library for eBay REST API.
[![NuGet version](https://img.shields.io/nuget/v/CMS365.EbaySharp.svg?maxAge=3600)](https://www.nuget.org/packages/CMS365.EbaySharp/)
![GitHub last commit (main)](https://img.shields.io/github/last-commit/CMS365-PTY-LTD/EbaySharp/main.svg?logo=github)
[![NuGet Downloads](https://img.shields.io/nuget/dt/CMS365.EbaySharp.svg?logo=nuget)](https://www.nuget.org/packages/CMS365.EbaySharp/)
[![Build status](https://img.shields.io/azure-devops/build/cms-365/EbaySharp/9.svg?logo=azuredevops)](https://cms-365.visualstudio.com/EbaySharp/_build?definitionId=9)
[![License](https://img.shields.io/badge/license-MIT-green)](./LICENSE)

EbaySharp is a .NET library that enables you to authenticate and make REST API calls to eBay. It's used for creating listings and managing orders using C# and .NET
# Installation
EbaySharp is [available on NuGet](https://www.nuget.org/packages/CMS365.EbaySharp/). Use the package manager
console in Visual Studio to install it:

```pwsh
Install-Package CMS365.EbaySharp
```
# API support

| EbaySharp version    | eBay REST API version            
| -------------------- | -------------------------------- 
| 1.1.X                | Taxonomy Taxonomy API v1.0.1    

EbaySharp currently supports the following Facebook Graph APIs:

-   Access and Security
    -   [Getting the access token](#access-and-security)
-   Using the EbaySharp
    -   [Using the EbaySharp](#using-the-EbaySharp)
    -   [Taxonomy](#taxonomy)
        -   [Get default category tree id](#get-default-category-tree-id)
        -   [Get category suggestions](#get-category-suggestions)

## Access and Security
You will need Clinet ID and Client Secret to genertae an access token. Visit https://developer.ebay.com/my/keys and create both.
Execute following lines and you will get ClientCredentials object which contains the access token.
```C#
IdentityController identityController = new IdentityController();
ClientCredentials creds = await identityController.GetClientCredentials(YOUR CLINET ID, YOUR CLIENT SECRET);
```
We have now got an access token which will be used to call other functions.

## Using the EbaySharp
 Initialize the instance with the access token.
```C#
EbayController ebayController = new EbayController(creds.AccessToken);
```

## Taxonomy
You can see a list of Taxonomy methods here https://developer.ebay.com/api-docs/commerce/taxonomy/resources/methods
### Get default category tree id
```C#
CategoryTree categoryTree = await ebayController.GetDefaultCategoryTreeId([marketplace_id]);
```
You need to pass marketplace_id, please visit https://developer.ebay.com/api-docs/commerce/taxonomy/static/supportedmarketplaces.html for supported market places.
### Get category suggestions
```C#
CategorySuggestionsResponse categorySuggestionsResponse = await ebayController.GetCategorySuggestions([category tree ID], [product title]);
```
You need to pass Category Tree ID and the product title you are searcjing categories for.