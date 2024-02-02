# EbaySharp: A .NET wrapper library for eBay REST API.

[![NuGet version](https://img.shields.io/nuget/v/CMS365.EbaySharp.svg?maxAge=3600)](https://www.nuget.org/packages/CMS365.EbaySharp/)
![GitHub last commit (main)](https://img.shields.io/github/last-commit/CMS365-PTY-LTD/EbaySharp/main.svg?logo=github)
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

| EbaySharp version | eBay REST API version   |
| ----------------- | ----------------------- |
| 6.2.X             | Inventory API v1.17.2   |
|                   | Metadata API v1.7.1     |
|                   | Taxonomy API v1.0.1     |
|                   | Fulfillment API v1.20.3 |

EbaySharp currently supports the following Ebay REST APIs:

- Access and Security
  - [Getting a user access token](#access-and-security)
- Using the EbaySharp
  - [Using the EbaySharp](#using-the-EbaySharp)
  - [Sell](#sell)
    - [Inventory](#inventory)
        - [Listing](#listing)
            - [Bulk migrate listings](#bulk-migrate-listings)
        - [Inventory item](#inventory-item)
            - [Get inventory items](#get-inventory-items)
            - [Get inventory item](#get-inventory-item)
            - [Create or replace inventory item](#create-or-replace-inventory-item)
            - [Delete inventory item](#delete-inventory-item)
        - [Inventory location](#inventory-locations)
            - [Get inventory locations](#get-inventory-locations)
            - [Get inventory location](#get-inventory-location)
            - [Create inventory location](#create-inventory-location)
            - [Delete inventory location](#delete-inventory-location)
        - [Offer](#offer)
            - [Get offers](#get-offers)
            - [Get offer](#get-offer)
            - [Create offer](#create-offer)
            - [Update offer](#update-offer)
            - [Publish offer](#publish-offer)
            - [Withdraw offer](#withdraw-offer)
            - [Delete offer](#delete-offer)
    - [Fulfillment](#fulfillment)
        - [Order](#order)
            - [Shipping fulfillment](#shipping-fulfillment)
                - [Get shipping fulfillment](#get-shipping-fulfillment)
            - [Get orders by order numbers](#get-orders-by-order-numbers)
            - [Get orders by filter](#get-orders-by-filter)
    - [Metadata](#metadata)
        - [Marketplace](#Marketplace)
            - [Get return policies](#get-return-policies)
  - [Commerce](#Commerce)
    - [Taxonomy](#taxonomy)
        - [Category Tree](#category-tree)
            - [Get default category tree ID](#get-default-category-tree-ID)
            - [Get category suggestions](#get-category-suggestions)
            - [Get category tree](#get-category-tree)
  

# Access and Security

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
public async Task<string> GetRefreshToken()
{
    string secureURL="replace with the URL of the thank you page";
    EbaySharp.Controllers.IdentityController identityController = new EbaySharp.Controllers.IDentityController();
    string refreshToken = await IdentityController.GetRefreshToken(ReplaceYourClientID, ReplaceYourClientSecret, 
        , secureURL, Replace with RU);
}
```

This method returns a refresh token which is valID for 18 months. You will need to re run this function after 18 months when refresh token has expired. We will use the refresh token and generate an access token.

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

# Sell

## Inventory

You can see a list of Inventory methods [here](https://developer.ebay.com/api-docs/sell/inventory/resources/methods)
### Listing

#### Bulk migrate listings
If you have already created your listing using old API (for example .NET C# SDK), you will need to migrate all listing to new REST API. You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/listing/methods/bulkMigrateListing)

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
BulkMigrateListingResponse bulkMigrateListingResponse = await ebayController.BulkMigrate(bulkMigrateListingRequest);

```
### Inventory Item
#### Get inventory items
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/inventory_item/methods/getInventoryItems)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
InventoryItemsList inventoryItemsList = await ebayController.GetInventoryItems(limit, offset);

```
#### Get inventory item
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/inventory_item/methods/getInventoryItem)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
InventoryItem inventoryItem = await ebayController.GetInventoryItem(SKU);

```
#### Create or replace inventory item
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/inventory_item/methods/createOrReplaceInventoryItem)

```C#

Dictionary<string, string[]> aspects = new Dictionary<string, string[]>
{
    { "Brand", new[] { "GoPro" } },
    { "Type", new[] { "Helmet/Action" } }
};

await ebayController.CreateOrReplaceInventoryItem("test-sku-api", new InventoryItem()
{
    Availability = new Availability() { ShipToLocationAvailability = new ShipToLocationAvailability() { Quantity = 3 } },
    Condition = ConditionEnum.NEW,
    Product = new Product()
    {
        Title = "Creating from REST API, please don't buy",
        Description = "I am created by the REST API",
        Aspects = aspects,
        Brand = "GoPro",
        MPN = "CHDHX-401",
        ImageUrls = new[] { "https://i.ebayimg.com/images/g/OKsAAOSwr2VlsUPx/s-l1600.jpg", "https://i.ebayimg.com/images/g/a9AAAOSw2IVlsUPz/s-l1600.jpg" }
    },
    //Find locale information here https://developer.ebay.com/api-docs/static/rest-request-components.html#marketpl
    Locale = "en-AU"
});

```
#### Delete inventory item
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/inventory_item/methods/deleteInventoryItem)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
await ebayController.DeleteInventoryItem(SKU);

```
### Inventory Location
#### Get inventory locations
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/location/methods/getInventoryLocations)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
InventoryLocations inventoryLocations = await ebayController.GetInventoryLocations(limit, offset);

```
#### Get inventory location
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/location/methods/getInventoryLocation)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
InventoryLocation inventoryLocation = await ebayController.GetInventoryLocation(merchantLocationKey);

```
#### Create inventory location
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/location/methods/createInventoryLocation)

```C#

await ebayController.CreateInventoryLocation(new InventoryLocation()
{
    MerchantLocationKey = merchantLocationKey,
    LocationTypes = new List<StoreTypeEnum>() { StoreTypeEnum.WAREHOUSE },
    MerchantLocationStatus = StatusEnum.ENABLED,
    Location = new Location()
    {
        Address = new Address()
        {
            PostalCode = "3698",
            Country = CountryCodeEnum.AU
        }
    }
});

```
#### Delete inventory location
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/location/methods/deleteInventoryLocation)

```C#

await ebayController.DeleteInventoryLocation(merchantLocationKey);

```
### Offer
#### Get offers
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/offer/methods/getOffers)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
OffersList offersList = await ebayController.GetOffers(SKU);

```
#### Get offer
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/offer/methods/getOffer)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
Offer offer = await ebayController.GetOffer(offerID);

```
#### Create offer
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/offer/methods/createOffer)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
Offer offer = new Offer()
{
    Sku = SKU,
    MarketplaceId = MarketplaceEnum.EBAY_AU,
    Format = FormatTypeEnum.FIXED_PRICE,
    PricingSummary = new PricingSummary()
    {
        Price = new Amount()
        {
            Currency = "AUD",
            Value = "75"
        }
    },
    MerchantLocationKey = inventoryLocation.MerchantLocationKey,
    CategoryId = "162480",
    ListingPolicies = new ListingPolicies()
    {
        FulfillmentPolicyId = "ReplaceYourFulfillmentPolicyId",
        PaymentPolicyId = "ReplaceYourPaymentPolicyId",
        ReturnPolicyId = "ReplaceYourReturnPolicyId"
    }
};
OfferCreated offerCreated = await ebayController.CreateOffer(offer, "en-AU");

```
#### Update offer
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/offer/methods/updateOffer)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
Offer offer = await ebayController.GetOffer(offerId);
offer.PricingSummary.Price.Value = "100";
await ebayController.UpdateOffer(offerId, offer, "en-AU");
```
#### Publish offer
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/offer/methods/publishOffer)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
OfferPublished offerPublished = await ebayController.PublishOffer(offerId, "en-AU");
```
#### Withdraw offer
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/offer/methods/withdrawOffer)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
OfferWithdrawn offerWithdrawn = await ebayController.WithdrawOffer(offerId);
```
#### Delete offer
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/offer/methods/deleteOffer)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
await ebayController.DeleteOffer(offerId);
```
## Fulfillment
You can find more detail [here](https://developer.ebay.com/api-docs/sell/fulfillment/resources/methods)
### Order
#### Shipping Fulfillment
##### Get shipping Fulfillments
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/offer/methods/withdrawOffer)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
Fulfillments fulfillments = await ebayController.GetShippingFulfillments("Order Number");
```
#### Get orders by order numbers
You can find more detail [here](https://developer.ebay.com/api-docs/sell/fulfillment/resources/order/methods/getOrders)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
Orders orders = await ebayController.GetOrders(new string[] { "ORDERNUMBER", "ORDERNUMBER" });
```
#### Get orders by filter
You can find more detail [here](https://developer.ebay.com/api-docs/sell/fulfillment/resources/order/methods/getOrders)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
string dateRange = $"{(DateTime.UtcNow.AddDays(-10).ToString("yyyy-MM-ddThh:mm:00.0Z"))}..{(DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:00.0Z"))}";
Orders orders = await ebayController.GetOrders($"creationdate:[{dateRange}]",50);
or
orders = await ebayController.GetOrders($"lastmodifieddate:[{dateRange}]");
or
orders = await ebayController.GetOrders("orderfulfillmentstatus:{NOT_STARTED|IN_PROGRESS}");
```

## Metadata
You can see a list of Metadata methods [here](https://developer.ebay.com/api-docs/sell/metadata/resources/methods)
### Marketplace
#### Get return policies
You need to pass MarketplaceID, please visit [here](https://developer.ebay.com/api-docs/commerce/taxonomy/static/supportedmarketplaces.html) for supported market places.
```C#
ReturnPoliciesList returnPoliciesList = await ebayController.GetReturnPolicies("EBAY_US");
```
# Commerce

## Taxonomy

You can see a list of Taxonomy methods [here](https://developer.ebay.com/api-docs/commerce/taxonomy/resources/methods)
### Category Tree

#### Get default category tree ID
You need to pass MarketplaceID, please visit [here](https://developer.ebay.com/api-docs/commerce/taxonomy/static/supportedmarketplaces.html) for supported market places.
```C#
CategoryTreeID categoryTreeID = await ebayController.GetDefaultCategoryTreeId("EBAY_US");
```
### Get category suggestions
You need to pass a Category Tree ID and the product title you are searching categories for.
```C#
CategorySuggestionsList categorySuggestionsList = await ebayController.GetCategorySuggestions(15, "I am a table, look for me");
```
### Get category tree
You need to pass a Category Tree ID.
```C#
CategoryTree categoryTree = await ebayController.GetCategoryTree(15);
```


