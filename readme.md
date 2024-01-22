# EbaySharp: A .NET wrapper library for eBay REST API.

[![NuGet version](https://img.shields.io/nuget/v/CMS365.EbaySharp.svg?maxAge=3600)](https://www.nuget.org/packages/CMS365.EbaySharp/)
![GitHub last commit (main)](https://img.shields.io/github/last-commit/CMS365-PTY-LTD/EbaySharp/main.svg?logo=github)
[![NuGet Downloads](https://img.shields.io/nuget/dt/CMS365.EbaySharp.svg?logo=nuget)](https://www.nuget.org/packages/CMS365.EbaySharp/)
[![Build status](https://img.shields.io/azure-devops/build/cms-365/EbaySharp/9.svg?logo=azuredevops)](https://cms-365.visualstudio.com/EbaySharp/_build?definitionID=9)
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
  - [Sell](#sell)
    - [Inventory](#inventory)
        - [Listing](#listing)
            - [Bulk migrate listings](#bulk-migrate-listings)
            - [Get inventory items](#get-inventory-items)
            - [Get inventory item](#get-inventory-item)
            - [Delete inventory item](#delete-inventory-item)
        - [Offer](#offer)
            - [Get offers](#get-offers) 
    - [Metadata](#metadata)
        - [Marketplace](#Marketplace)
            - [Get return policies](#get-return-policies)
  - [Commerce](#Commerce)
    - [Taxonomy](#taxonomy)
        - [Category Tree](#category-tree)
            - [Get default category tree ID](#get-default-category-tree-ID)
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
Log in with your store user ID and password and you will be redirected to the following page

![alt text](https://github.com/CMS365-PTY-LTD/EbaySharp/blob/main/EbaySharp/Screenshots/consent.png?raw=true)

Copy the URL of the thank you page and assign it to a variable called "secureURL" and execute the following function.
```C#
public async Task<string> GetRefreshTokenAsync()
{
    string secureURL="replace with the URL of the thank you page";
    EbaySharp.Controllers.IDentityController IDentityController = new EbaySharp.Controllers.IDentityController();
    string refreshToken = await IDentityController.GetRefreshTokenAsync(ReplaceYourClientID, ReplaceYourClientSecret, 
        , secureURL, Replace with RU);
}
```

This method returns a refresh token which is valID for 18 months. You will need to re run this function after 18 months when refresh token has expired. We will use the refresh token and generate an access token.

```C#
IDentityController IDentityController=new IDentityController();
var clientCredentials = await IDentityController.GetClientCredentials(ReplaceYourClientID, ReplaceYourClientSecret, ReplaceWithRefreshToken , ReplaceWithScopes);
```
This method now gives you ClientCredentialsResponse object which contains an access token.

## Using the EbaySharp

Initialize the instance with the access token.

```C#
EbayController ebayController = new EbayController(clientCredentials.AccessToken);
```

## Sell

### Inventory

You can see a list of Inventory methods [here](https://developer.ebay.com/api-docs/sell/inventory/resources/methods)
#### Listing

##### Bulk migrate listings
If you have already created your listing using old API (for example .NET C# SDK), you will need to migrate all listing to new REST API.
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/listing/methods/bulkMigrateListing)

```C#
BulkMigrateListingRequest bulkMigrateListingRequest = new BulkMigrateListingRequest()
{
    Requests = new BulkMigrateListingRequestItem[]
    {
        new BulkMigrateListingRequestItem(){ListingID = "21432432432" },
        new BulkMigrateListingRequestItem(){ListingID = "78658678678" }
    }
});
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
BulkMigrateListingResponse bulkMigrateListingResponse = await ebayController.BulkMigrateAsync(bulkMigrateListingRequest);

```
##### Get inventory items
You can get list of existing items, you need to pass limit (default is 25 and max is 200) and offset (default for first page is 0).
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/inventory_item/methods/getInventoryItems)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
InventoryItemsResponse bulkMigrateListingResponse = await ebayController.GetInventoryItems(limit, offset);

```
##### Get inventory item
You can get an item based on a SKU
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/inventory_item/methods/getInventoryItem)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
InventoryItemResponse inventoryItemResponse = await ebayController.GetInventoryItem(SKU);

```
##### Delete inventory item
You can delete an item based on a SKU
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/inventory_item/methods/deleteInventoryItem)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
await ebayController.DeleteInventoryItem(SKU);

```
#### Offer
##### Get offers
You can get offers based on a SKU
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/offer/methods/getOffers)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
OffersResponse offersResponse = await ebayController.GetOffers(SKU);

```

### Metadata
You can see a list of Metadata methods [here](https://developer.ebay.com/api-docs/sell/metadata/resources/methods)
#### Marketplace
##### Get return policies

```C#
ReturnPoliciesResponse returnPoliciesResponse = await ebayController.GetReturnPoliciesAsync("EBAY_US");
```

You need to pass MarketplaceID, please visit [here](https://developer.ebay.com/api-docs/commerce/taxonomy/static/supportedmarketplaces.html) for supported market places.

## Commerce

### Taxonomy

You can see a list of Taxonomy methods [here](https://developer.ebay.com/api-docs/commerce/taxonomy/resources/methods)
#### Category Tree

##### Get default category tree ID

```C#
CategoryTreeIDResponse categoryTreeIDResponse = await ebayController.GetDefaultCategoryTreeIDAsync("EBAY_US");
```

You need to pass MarketplaceID, please visit [here](https://developer.ebay.com/api-docs/commerce/taxonomy/static/supportedmarketplaces.html) for supported market places.

#### Get category suggestions

```C#
CategorySuggestionsResponse categorySuggestionsResponse = await ebayController.GetCategorySuggestionsAsync(15, "I am a table, look for me");
```

You need to pass a Category Tree ID and the product title you are searching categories for.

#### Get category tree

```C#
CategoryTreeResponse categorySuggestionsResponse = await ebayController.GetCategoryTreeAsync(15);
```

You need to pass a Category Tree ID.



