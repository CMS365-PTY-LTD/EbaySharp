# EbaySharp: A .NET wrapper library for eBay REST API.

[![NuGet](https://img.shields.io/nuget/v/CMS365.EbaySharp.svg?logo=nuget)](https://www.nuget.org/packages/CMS365.EbaySharp/)
![NuGet Downloads](https://img.shields.io/nuget/dt/CMS365.EbaySharp)
![GitHub last commit (main)](https://img.shields.io/github/last-commit/CMS365-PTY-LTD/EbaySharp/main.svg?logo=github)
[![Build status](https://img.shields.io/azure-devops/build/cms-365/EbaySharp/9.svg?logo=azuredevops)](https://cms-365.visualstudio.com/EbaySharp/_build?definitionID=9)
[![License](https://img.shields.io/badge/license-MIT-green)](./LICENSE)
![GitHub Stars](https://img.shields.io/github/stars/CMS365-PTY-LTD/EbaySharp?style=social)

EbaySharp is a .NET library that enables you to authenticate and make REST API calls to eBay. This .NET SDK used for creating listings and managing orders using C#.

# Installation

EbaySharp is [available on NuGet](https://www.nuget.org/packages/CMS365.EbaySharp/). Use the package manager
console in Visual Studio to install it:

```pwsh
Install-Package CMS365.EbaySharp
```

# API support

| EbaySharp version | eBay REST API version       |
| ----------------- | ----------------------------|
| 9.X.X             | Analytics API v1_beta.0.1   |
|                   | Browse API v1.20.1          |
|                   | Feed API v1.3.1             |
|                   | Finances API v1.17.2        |
|                   | Fulfillment API v1.20.7     |
|                   | Identity API v1.1.0         |
|                   | Inventory API v1.18.2       |
|                   | Key Management API v1.0.0   |
|                   | Metadata API v1.9.0         |
|                   | Stores API v1.0.0           | 
|                   | Taxonomy API v1.1.0         |
|                   | Trading API (Legacy) v1363  |

EbaySharp currently supports the following Ebay REST APIs:

- Access and Security
  - [Getting a user access token](#access-and-security)
- Using the EbaySharp
  - [Using the EbaySharp](#using-the-EbaySharp)
  - [Buy](#buy)
    - [Browse](#browse)
        - [Item](#item)
            - [Get item](#get-item)
  - [Commerce](#commerce)
    - [Taxonomy](#taxonomy)
        - [Category Tree](#category-tree)
            - [Get category suggestions](#get-category-suggestions)
            - [Get category tree](#get-category-tree)
            - [Get default category tree Id](#get-default-category-tree-Id)
  - [Developer](#developer)
    - [Analytics](#analytics)
        - [Rate Limit](#rate-limit)
            - [Get rate limits](#get-rate-limits)
            - [Get user rate limits](#get-user-rate-limits)
    - [Key Management](#key-management)
        - [Signing Key](#signing-key)
            - [Get signing keys](#get-signing-keys)
            - [Get signing key](#get-signing-key)
            - [Create signing key](#create-signing-key)
  - [Sell](#sell)
    - [Feed](#feed)
        - [Task](#task)
            - [Get result file](#get-result-file)
    - [Finances](#finances)
        - [Transaction](#transaction)
            - [Get transactions](#get-transactions)
            - [Get transaction summary](#get-transaction-summary)
        - [Payout](#payout)
            - [Get payout summary](#get-payout-summary)
            - [Get payouts](#get-payouts)
            - [Get payout](#get-payout)
    - [Fulfillment](#fulfillment)
        - [Order](#order)
            - [Get orders by order numbers](#get-orders-by-order-numbers)
            - [Get orders by filter](#get-orders-by-filter)
            - [Shipping fulfillment](#shipping-fulfillment)
                - [Create shipping fulfillment](#create-shipping-fulfillment)
                - [Get shipping fulfillments](#get-shipping-fulfillments)
                - [Get shipping fulfillment](#get-shipping-fulfillment)
    - [Identity](#identity)
        - [User](#user)
            - [Get user](#get-user)
    - [Inventory](#inventory)
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
        - [Listing](#listing)
            - [Bulk migrate listings](#bulk-migrate-listings)
            - [Create a new listing](#create-a-new-listing)
            - [Revise a listing](#revise-a-listing)
            - [Update an active listing](#update-an-active-listing)
            - [End a listing](#end-a-listing)
        - [Offer](#offer)
            - [Get offers](#get-offers)
            - [Get offer](#get-offer)
            - [Create offer](#create-offer)
            - [Update offer](#update-offer)
            - [Publish offer](#publish-offer)
            - [Withdraw offer](#withdraw-offer)
            - [Delete offer](#delete-offer)
    - [Metadata](#metadata)
        - [Marketplace](#marketplace)
            - [Get return policies](#get-return-policies)
    - [Stores](#stores)
        - [Store](#store)
            - [Get store categories](#get-store-categories)
    - [Trading](#trading)
        - [Standard Listing Calls](#standard-listing-calls)
            - [GetSellerList](#getsellerlist)
            - [GetAccount](#getaccount)
            
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
    EbaySharp.Controllers.AuthenticationController authenticationController = new EbaySharp.Controllers.AuthenticationController();
    string refreshToken = await authenticationController.GetRefreshToken(ReplaceYourClientId, ReplaceYourClientSecret, 
        , secureURL, Replace with RU);
}
```

This method returns a refresh token which is valid for 18 months or If you change your user/id or password. You will need to re run this function after 18 months when refresh token has expired. We will use the refresh token and generate an access token.

```C#
AuthenticationController authenticationController=new AuthenticationController();
var clientCredentials = await authenticationController.GetClientCredentials(ReplaceYourClientId, ReplaceYourClientSecret, ReplaceWithRefreshToken , ReplaceWithScopes);
```
Provide scope separated by a space, for example https://api.ebay.com/oauth/api_scope https://api.ebay.com/oauth/api_scope/sell.marketing.readonly
This method now gives you ClientCredentialsResponse object which contains an access token.

## Using the EbaySharp

Initialize the instance with the access token.

```C#
EbayController ebayController = new EbayController(clientCredentials.AccessToken);
```
# Buy

## Browse

You can see a list of Browse API methods [here](https://developer.ebay.com/api-docs/buy/browse/resources/methods)
### Item
#### Get item
You can find more detail [here](https://developer.ebay.com/api-docs/buy/browse/resources/item/methods/getItem)
You need to pass an item Id.
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
Item item = await ebayController.GetItem("355731616267");
```
# Commerce

## Taxonomy

You can see a list of Taxonomy API methods [here](https://developer.ebay.com/api-docs/commerce/taxonomy/resources/methods)
### Category Tree
#### Get category suggestions
You can find more detail [here](https://developer.ebay.com/api-docs/commerce/taxonomy/resources/category_tree/methods/getCategorySuggestions)
You need to pass a Category Tree Id and the product title you are searching categories for.
```C#
CategorySuggestionsList categorySuggestionsList = await ebayController.GetCategorySuggestions(15, "I am a table, look for me");
```
#### Get category tree
You can find more detail [here](https://developer.ebay.com/api-docs/commerce/taxonomy/resources/category_tree/methods/getCategoryTree)
You need to pass a Category Tree ID.
```C#
CategoryTree categoryTree = await ebayController.GetCategoryTree(15);
```
#### Get default category tree Id
You can find more detail [here](https://developer.ebay.com/api-docs/commerce/taxonomy/resources/category_tree/methods/getDefaultCategoryTreeId)
You need to pass MarketplaceId, please visit [here](https://developer.ebay.com/api-docs/commerce/taxonomy/static/supportedmarketplaces.html) for supported market places.
```C#
CategoryTreeId categoryTreeId = await ebayController.GetDefaultCategoryTreeId("EBAY_US");
```
# Developer

## Analytics

You can see a list of Analytics API methods [here](https://developer.ebay.com/api-docs/developer/analytics/resources/methods)
### Rate Limits

#### Get rate limits
You can find more detail [here](https://developer.ebay.com/api-docs/developer/analytics/resources/rate_limit/methods/getRateLimits)
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
RateLimits rateLimits = await ebayController.GetRateLimits();
```
#### Get user rate limits
You can find more detail [here](https://developer.ebay.com/api-docs/developer/analytics/resources/rate_limit/methods/getUserRateLimits)
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
RateLimits rateLimits = await ebayController.GetUserRateLimits();
```
## Key Management

You can see a list of Key management API methods [here](https://developer.ebay.com/api-docs/developer/key-management/resources/methods)
### Signing key

#### Get signing keys
You can find more detail [here](https://developer.ebay.com/api-docs/developer/key-management/resources/signing_key/methods/getSigningKeys)
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
SigningKeys signingKeys = await ebayController.GetSigningKeys();
```
#### Get signing key
You can find more detail [here](https://developer.ebay.com/api-docs/developer/key-management/resources/signing_key/methods/getSigningKey)
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
SigningKeys signingKeys = await ebayController.GetSigningKey(string signinKeyId);
```
#### Create signing key
You can find more detail [here](https://developer.ebay.com/api-docs/developer/key-management/resources/signing_key/methods/createSigningKey)
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
signingKey = await ebayController.CreateSigningKey(SigningKeyCipher.ED25519);
```
# Sell
## Feed
You can see a list of Feed API methods [here](https://developer.ebay.com/api-docs/sell/feed/resources/methods)
### Task
#### Get result file
You can find more detail [here](https://developer.ebay.com/api-docs/sell/feed/resources/task/methods/getResultFile)
```C#
ResultFile resultFile = await ebayController.GetResultFile([TASK_ID]);
await resultFile.SaveUncompressed("C:\\Work");
```
## Finances
You can see a list of Finances API methods [here](https://developer.ebay.com/api-docs/sell/finances/resources/methods)
### Transaction
<span style="color:red">Important! Due to EU & UK Payments regulatory requirements, an additional security verification via Digital Signatures is required for certain API calls that are made on behalf of EU/UK sellers, including all Finances API methods.</span>
```C#
SigningKey signingKey = await ebayController.CreateSigningKey(SigningKeyCipher.ED25519);
```
#### Get transactions
You can find more detail [here](https://developer.ebay.com/api-docs/sell/finances/resources/transaction/methods/getTransactions)
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
Transactions transactions = await ebayController.GetTransactions(signingKey);
or
Transactions transactions = await ebayController.GetTransactions();
```
#### Get transaction summary
You can find more detail [here](https://developer.ebay.com/api-docs/sell/finances/resources/transaction/methods/getTransactionSummary)
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
TransactionSummary transactionSummary = await ebayController.GetTransactionSummary(signingKey, "transactionStatus:{PAYOUT}");
or
TransactionSummary transactionSummary = await ebayController.GetTransactionSummary("transactionStatus:{PAYOUT}");
```
### Payout
#### Get payout summary
You can find more detail [here](https://developer.ebay.com/api-docs/sell/finances/resources/payout/methods/getPayoutSummary)
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
PayoutSummary payoutSummary = await ebayController.GetPayoutSummary(signingKey, "payoutDate:[2025-02-01T00:00:01.000Z..2025-03-20T00:00:01.000Z]");
or
PayoutSummary payoutSummary = await ebayController.GetPayoutSummary("payoutDate:[2025-02-01T00:00:01.000Z..2025-03-20T00:00:01.000Z]");
```
#### Get payouts
You can find more detail [here](https://developer.ebay.com/api-docs/sell/finances/resources/payout/methods/getPayouts)
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
PayoutList payoutList = await ebayController.GetPayouts(signingKey, "payoutStatus:{SUCCEEDED}");
or
PayoutList payoutList = await ebayController.GetPayouts("payoutStatus:{SUCCEEDED}");
```
#### Get payout
You can find more detail [here](https://developer.ebay.com/api-docs/sell/finances/resources/payout/methods/getPayout)
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
Payout payout = await ebayController.GetPayout(signingKey, 6801425208);
or
Payout payout = await ebayController.GetPayout(6801425208);
```
## Fulfillment
You can find more detail [here](https://developer.ebay.com/api-docs/sell/fulfillment/resources/methods)
### Order


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
#### Shipping Fulfillment
##### Create shipping Fulfillment
You can find more detail [here](https://developer.ebay.com/api-docs/sell/fulfillment/resources/order/shipping_fulfillment/methods/createShippingFulfillment)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
List<EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order.Order> allOrders = new List<EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order.Order>();
int totalCount = 0;
do
{
    var eBayOrders = await ebayController.GetOrders("orderfulfillmentstatus:{NOT_STARTED|IN_PROGRESS}", 50, totalCount);
    totalCount = eBayOrders.Total;
    allOrders.AddRange(eBayOrders.OrderList);
} while (allOrders.Count < totalCount);
EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order.Order order = allOrders.Where(x => x.OrderId == orderTracking.OrderNumber).FirstOrDefault();

//Execute the following block in a loop If you have multiple tracking numbers.
await ebayController.CreateShippingFulfillment("Order Number", new EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order.ShippingFulfillment.Fulfillment()
{
    LineItems = order.LineItems.Select(x => new EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order.ShippingFulfillment.LineItem()
    {
        LineItemId = x.LineItemId,
        Quantity = x.Quantity
    }).ToList(),
    TrackingNumber = "Tracking Number",
    ShippingCarrierCode = "Courier Name",
    ShippedDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.0Z")
});
```
##### Get shipping Fulfillments
You can find more detail [here](https://developer.ebay.com/api-docs/sell/fulfillment/resources/order/shipping_fulfillment/methods/getShippingFulfillments)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
Fulfillments fulfillments = await ebayController.GetShippingFulfillments("Order Number");
```
##### Get shipping Fulfillment
You can find more detail [here](https://developer.ebay.com/api-docs/sell/fulfillment/resources/order/shipping_fulfillment/methods/getShippingFulfillment)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
Fulfillment fulfillment = await ebayController.GetShippingFulfillment("Order Number", "Fulfillment Id");
```
## Identity
You can see a list of Identity API methods [here](https://developer.ebay.com/api-docs/commerce/identity/resources/methods)
### User
#### Get user
You can find more detail [here](https://developer.ebay.com/api-docs/commerce/identity/resources/user/methods/getUser)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
User user = await ebayController.GetUser();

```

## Inventory
You can see a list of Inventory API methods [here](https://developer.ebay.com/api-docs/sell/inventory/resources/methods)
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

Dictionary<string, string[]> aspects = new()
{
    { "Brand", new[] { "GoPro" } },
    { "Type", new[] { "Helmet/Action" } }
};

CreatedOrReplacedInventoryItem createdOrReplacedInventoryItem = await ebayController.CreateOrReplaceInventoryItem("test-sku-api", new InventoryItem()
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

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
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
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
await ebayController.DeleteInventoryLocation(merchantLocationKey);

```
### Listing
#### Bulk migrate listings
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/listing/methods/bulkMigrateListing)
If you have already created your listing using old API (for example .NET C# SDK), you will need to migrate all listing to new REST API. You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/listing/methods/bulkMigrateListing)

```C#
BulkMigrateListingRequest bulkMigrateListingRequest = new BulkMigrateListingRequest()
{
    Requests = new BulkMigrateListingRequestItem[]
    {
        new BulkMigrateListingRequestItem(){ListingId = "21432432432" },
        new BulkMigrateListingRequestItem(){ListingId = "78658678678" }
    }
});
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
BulkMigrateListingResponse bulkMigrateListingResponse = await ebayController.BulkMigrate(bulkMigrateListingRequest);

```
#### Create a new listing
If you want to create a new listing, you will need to perform following 3 steps.

1 - Create a new inventory item
```C#

MarketplaceEnum? marketplaceId = MarketplaceEnum.EBAY_AU (for example)
CurrencyCodeEnum? CurrencyCodeId = CurrencyCodeEnum.AUD (for example)

EbaySharp.Entities.Sell.Inventory.InventoryItem.InventoryItem inventoryItem = new EbaySharp.Entities.Sell.Inventory.InventoryItem.InventoryItem()
{
    Condition = ConditionEnum.NEW,
    Availability = new Availability() { ShipToLocationAvailability = new ShipToLocationAvailability() { Quantity = 3, AllocationByFormat = new AllocationByFormat() { FixedPrice = 3 } } },
    Product = new EbaySharp.Entities.Sell.Inventory.InventoryItem.Product()
    {
        Title = YOUR PRODCT TITLE,
        Aspects = DICTIONARY OF ASPECTS IN Dictionary<string, string[]> FORMAT,
        Brand = PRODUCT BRAND,
        MPN = SKU/MPN,
        ImageUrls = ARRAY OF IMAGE URLS
    },
    Locale = LOCALE OF YOUR STORE
};
CreatedOrReplacedInventoryItem createdOrReplacedInventoryItem = await ebayController.CreateOrReplaceInventoryItem(UNIQUE SKU OF THE PRODUCT, inventoryItem);
```
2 - Create a new offer
You can see detail [here](https://github.com/CMS365-PTY-LTD/EbaySharp?tab=readme-ov-file#create-offer) 

3 - Publish offer
You can see detail [here](https://github.com/CMS365-PTY-LTD/EbaySharp?tab=readme-ov-file#publish-offer)
#### Revise a listing
If you want to revise a listing, you will need to perform following 4 steps.

1 - Get an existing inventory item you want to revise
You can see detail [here](https://github.com/CMS365-PTY-LTD/EbaySharp?tab=readme-ov-file#get-inventory-item)
2 - Get an existing offer
```C3
Offers offers = await ebayController.GetOffers(product.SKU);
Offer offer = offers.OfferList.FirstOrDefault();
```
3 - Make changes in the inventory item or offer
```C#
string locale = "en-AU" //FOR EXAMPLE
inventoryItem.Product.Title = UPDATED TITLE;
offer.PricingSummary.Price.Value = NEW PRICE;
offer.AvailableQuantity = NEW STOCK;
await ebayController.CreateOrReplaceInventoryItem(product.SKU, inventoryItem);
await ebayController.UpdateOffer(offer.OfferId, offer, locale);

```
4 - Publish offer
```C#
OfferPublished offerPublished = await ebayController.PublishOffer(offer.OfferId, locale);
```
#### Update an active listing
If you want to update an existing active listing, you will need to perform following 3 steps.

1 - Get an existing inventory item you want to update
You can see detail [here](https://github.com/CMS365-PTY-LTD/EbaySharp?tab=readme-ov-file#get-inventory-item)
2 - Get an existing offer
```C3
Offers offers = await ebayController.GetOffers(product.SKU);
Offer offer = offers.OfferList.FirstOrDefault();
```
3 - Make changes in the inventory item or offer
```C#
string locale = "en-AU" //FOR EXAMPLE
inventoryItem.Product.Title = UPDATED TITLE;
offer.PricingSummary.Price.Value = NEW PRICE;
offer.AvailableQuantity = NEW STOCK;
await ebayController.CreateOrReplaceInventoryItem(product.SKU, inventoryItem);
await ebayController.UpdateOffer(offer.OfferId, offer, locale);

```
#### End a listing
If you want to end a listing, you will need to perform following 2 steps.

1 - Get an offer and set quantity to 0
```C#
Offers offers = await ebayController.GetOffers(SKU);
Offer offer = offers.OfferList.FirstOrDefault();
offer.AvailableQuantity = 0; //optional
```
2 - Withdraw offer
```C#
OfferWithdrawn offerWithdrawn = await ebayController.WithdrawOffer(offer.OfferId);
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
Offer offer = await ebayController.GetOffer(offerId);

```
#### Create offer
You can find more detail [here](https://developer.ebay.com/api-docs/sell/inventory/resources/offer/methods/createOffer)

```C#

EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
Offer offer = new Offer()
{
    SKU = SKU,
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
OfferUpdated offerUpdated = await ebayController.UpdateOffer(offerId, offer, "en-AU");
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


## Metadata
You can see a list of Metadata API methods [here](https://developer.ebay.com/api-docs/sell/metadata/resources/methods)
### Marketplace
#### Get return policies
You need to pass MarketplaceId, please visit [here](https://developer.ebay.com/api-docs/commerce/taxonomy/static/supportedmarketplaces.html) for supported market places.
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
ReturnPoliciesList returnPoliciesList = await ebayController.GetReturnPolicies("EBAY_US");
```

## Stores
You can see a list of Stores API methods [here](https://developer.ebay.com/api-docs/sell/stores/resources/methods)
### Store
#### Get store categories
You can find more detail [here](https://developer.ebay.com/api-docs/sell/stores/resources/store/methods/getStoreCategories)
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
StoreCategories storeCategories = await ebayController.GetStoreCategories();
```
## Trading
> [!WARNING]  
> This is a legacy API, I am adding methods based on a request only. You can see a list of Trading call categories [here](https://developer.ebay.com/devzone/xml/docs/reference/ebay/index.html)
### Standard Listing Calls
#### GetSellerList
This method is used to get a list of all active and ended items. You can find more detail [here](https://developer.ebay.com/devzone/xml/docs/reference/ebay/GetSellerList.html)
```C#
EbaySharp.Controllers.EbayController ebayController = new EbaySharp.Controllers.EbayController(clientCredentials.AccessToken);
int pageNumber = 0;
bool hasMoreResults = true;
while (hasMoreResults)
{
    GetSellerListResponse getSellerListResponse = await ebayController.GetItems(siteId, ++pageNumber, 200, DateTime.Now.AddDays(-87).ToString("O"), DateTime.Now.AddDays(33).ToString("O"));
    hasMoreResults = getSellerListResponse.HasMoreItems;
    //Process items response here.
}
```
#### GetAccount
This is a legacy XML call and you should be considering [Finances API](#finances) as a recommended approach and please read [Issue](https://github.com/CMS365-PTY-LTD/EbaySharp/issues/19) for more detail.

This method is used to get account information which contains transactions, payouts and invoice related data. You can find more detail [here](https://developer.ebay.com/devzone/xml/docs/reference/ebay/GetAccount.html)
```C#
//FOR EU
    SigningKey signingKey = await ebayController.CreateSigningKey(SigningKeyCipher.ED25519);
    int siteId = 3;

    //For AU
    //int siteId=15

    XNamespace ns = "urn:ebay:apis:eBLBaseComponents";
    XDocument xmlDocument = new XDocument(
        new XDeclaration("1.0", "utf-8", "yes"),
        new XElement(ns + "GetAccountRequest", new XAttribute("xmlns", ns),
            new XElement("RequesterCredentials",
                new XElement("eBayAuthToken", accessToken)
            ),
            new XElement("AccountEntrySortType", "AccountEntryFeeTypeAscending"),
            new XElement("AccountHistorySelection", "LastInvoice"),
            new XElement("Pagination",
                new XElement("EntriesPerPage", 10),
                new XElement("PageNumber", 1)
            )
        )
    );
    var memory = new MemoryStream();
    xmlDocument.Save(memory);
    string inputXml = Encoding.UTF8.GetString(memory.ToArray()).Replace("xmlns=\"\"", "");
    GetAccountResponse getAccountResponse = await ebayController.GetAccount(siteId, inputXml, signingKey);
    or
    GetAccountResponse getAccountResponse = await ebayController.GetAccount(siteId, inputXml);
```


