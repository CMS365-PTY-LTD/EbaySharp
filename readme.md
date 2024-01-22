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

| EbaySharp version | eBay REST API version |
| ----------------- | --------------------- |
| 1.0.X             | Inventory API 1.17.2  |
|                   | Metadata API v1.7.1   |
|                   | Taxonomy API v1.0.1   |

EbaySharp currently supports the following Ebay REST APIs:

- Access and Security
  - [Getting a user access token](#access-and-security)
- Using the EbaySharp
  - [Using the EbaySharp](#using-the-EbaySharp)
  - [Sales](#sales)
    - [Inventory](#inventory)
        - [Bulk migrate listings](#bulk-migrate-listings)
    - [Metadata](#metadata)
        - [Get return policies](#get-return-policies)
  - [Commerce](#Commerce)
    - [Taxonomy](#taxonomy)
        - [Get default category tree id](#get-default-category-tree-id)
        - [Get category suggestions](#get-category-suggestions)
        - [Get category tree](#get-category-tree)
  

## Access and Security

Create an account here https://developer.ebay.com/my/keys and generate keys for production.

For example: ![alt text](https://github.com/CMS365-PTY-LTD/EbaySharp/blob/main/EbaySharp/Screenshots/keys.png?raw=true)

Navigate to user tokens https://developer.ebay.com/my/auth/?env=production&index=0 and select following options.

![alt text](https://github.com/CMS365-PTY-LTD/EbaySharp/blob/main/EbaySharp/Screenshots/user_token.png?raw=true)

From the same page, generate the ebay redirect URL (called RU)

![alt text](https://github.com/CMS365-PTY-LTD/EbaySharp/blob/main/EbaySharp/Screenshots/ru.png?raw=true)

Copy the URL of the field "Your branded eBay Production Sign In (OAuth)" and open in a new browser in private mode and also save a copy of the URL for future use.
Log in with your store user id and password and you will be redirected to the following page

![alt text](https://github.com/CMS365-PTY-LTD/EbaySharp/blob/main/EbaySharp/Screenshots/consent.png?raw=true)

Copy the URL of the thank you page and assign it to a variable called "secureURL" and execute the following function.
```C#
public async Task<string> GetRefreshTokenAsync()
{
    string secureURL="repalce with the url of the thank you page";
    EbaySharp.Controllers.IdentityController identityController = new EbaySharp.Controllers.IdentityController();
    string refreshToken = await identityController.GetRefreshTokenAsync(ReplaceYourClientID, ReplaceYourClientSecret, 
        , secureURL, Replace with RU);
}
```

This method returns a refresh token whcih is valid for 18 months. You will need to re run this function after 18 months when refresh token has expired. We will use the refresh token and generate an access token.

```C#
IdentityController identityController=new IdentityController();
var clientCredentials = await identityController.GetClientCredentials(ReplaceYourClientID, ReplaceYourClientSecret, ReplaceWithRefreshToken , ReplaceWithScopes);
```
This method now gives you ClientCredentialsResponse object which contains an access token.

## Using the EbaySharp

Initialize the instance with the access token.

```C#
EbayController ebayController = new EbayController(clientCredentials.AccessToken);
```

## Sales

### Inventory

You can see a list of Inventory methods here https://developer.ebay.com/api-docs/sell/inventory/resources/methods

#### Bulk migrate listings
If you have already created your listing using old API (for example .NET C# SDK), you will need to migrate all listing to new REST API.

```C#
BulkMigrateListingResponse bulkMigrateListingResponse = await ebayController.BulkMigrateAsync(new BulkMigrateListingRequest()
{
    Requests = new BulkMigrateListingRequestItem[]
    {
        new BulkMigrateListingRequestItem(){ListingID = "Replace with item number" },
        new BulkMigrateListingRequestItem(){ListingID = "Replace with item number" }
    }
});
```

### Metadata
You can see a list of Metadata methods here https://developer.ebay.com/api-docs/sell/metadata/resources/methods

#### Get return policies

```C#
ReturnPoliciesResponse returnPoliciesResponse = await ebayController.GetReturnPoliciesAsync([MarketplaceID]);
```

You need to pass MarketplaceID, please visit https://developer.ebay.com/api-docs/commerce/taxonomy/static/supportedmarketplaces.html for supported market places.

## Commerce

### Taxonomy

You can see a list of Taxonomy methods here https://developer.ebay.com/api-docs/commerce/taxonomy/resources/methods

#### Get default category tree id

```C#
CategoryTreeIDResponse categoryTreeIDResponse = await ebayController.GetDefaultCategoryTreeIDAsync([MarketplaceID]);
```

You need to pass MarketplaceID, please visit https://developer.ebay.com/api-docs/commerce/taxonomy/static/supportedmarketplaces.html for supported market places.

#### Get category suggestions

```C#
CategorySuggestionsResponse categorySuggestionsResponse = await ebayController.GetCategorySuggestionsAsync([CategoryTreeID], [ProductTitle]);
```

You need to pass a Category Tree ID and the product title you are searching categories for.

#### Get category tree

```C#
CategoryTreeResponse categorySuggestionsResponse = await ebayController.GetCategoryTreeAsync([CategoryTreeID]);
```

You need to pass a Category Tree ID.



