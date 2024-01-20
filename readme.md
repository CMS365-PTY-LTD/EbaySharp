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
| 1.0.X             | Taxonomy API v1.0.1 
|                   | Metadata API v1.7.1   |

EbaySharp currently supports the following Ebay REST APIs:

- Access and Security
  - [Getting the application access token](#access-and-security)
- Using the EbaySharp
  - [Using the EbaySharp](#using-the-EbaySharp)
  - [Taxonomy](#taxonomy)
    - [Get default category tree id](#get-default-category-tree-id)
    - [Get category suggestions](#get-category-suggestions)
    - [Get category tree](#get-category-tree)
  - [Metadata](#metadata)
    - [Get return policies](#get-return-policies)

## Access and Security

Create a developer account here https://developer.ebay.com/my/keys and genertae keys for production.
For example: ![alt text](https://github.com/CMS365-PTY-LTD/EbaySharp/blob/main/EbaySharp/Screenshots/keys.png?raw=true)
Navigate to user tokens https://developer.ebay.com/my/auth/?env=production&index=0 and select following options.
![alt text](https://github.com/CMS365-PTY-LTD/EbaySharp/blob/main/EbaySharp/Screenshots/user_token?raw=true)
From the same page, genertae the ebay redirect url (called RU)
![alt text](https://github.com/CMS365-PTY-LTD/EbaySharp/blob/main/EbaySharp/Screenshots/ru?raw=true)
Copy the url for the field "Your branded eBay Production Sign In (OAuth)" and open a new browser in provate mode and also save a copy of the url for future use.
Log in with your store user id and password and you will be redirected ot the following page
![alt text](https://github.com/CMS365-PTY-LTD/EbaySharp/blob/main/EbaySharp/Screenshots/consent?raw=true)
Copy the url of the page and assing it to a varibale called "secureUrl" and execute the following funciton.
```C#
public async Task<string> GetRefreshTokenAsync()
{
    string secureUrl1 = "https://signin.ebay.com/ws/eBayISAPI.dll?ThirdPartyAuthSucessFailure&isAuthSuccessful=true&code=v%5E1.1%23i%5E1%23p%5E3%23f%5E0%23r%5E1%23I%5E3%23t%5EUl41Xzg6QUE5OEU0QzVEQkM3Q0NDQjAyMjM1RTAxMTQ3MEY1MjZfMF8xI0VeMjYw&expires_in=299";
    var client = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Post, "https://api.ebay.com/identity/v1/oauth2/token");

    string authorizationCode = Convert.ToBase64String(Encoding.UTF8.GetBytes("ReplaceYourClientID:ReplaceYourClientSecret"));

    request.Headers.Add("Authorization", $"Basic {authorizationCode}");
    var parsed = HttpUtility.ParseQueryString(secureUrl1);
    var collection = new List<KeyValuePair<string, string>>
    {
        new("redirect_uri", "Replace with your ru genertaed above"),
        new("grant_type", "authorization_code"),
        new("code",HttpUtility.UrlDecode(parsed["code"]))
    };
    var content = new FormUrlEncodedContent(collection);
    request.Content = content;
    var response = await client.SendAsync(request);
    JObject responseContent = JObject.Parse(await response.Content.ReadAsStringAsync());
    string refreshToken = responseContent.GetValue("refresh_token").ToString();
    return refreshToken;
}
```

This method returns you an access token and a refesh token (valid for 18 months), we will not use access token becasue this requires a manual step of generting a code form a brwoser.
We will use the refresh token and genertae an access token.

```C#
public async Task<ClientCredentialsResponse> GetEbayGetClientCredentials()
{
    var clientCredentials = await identityController.GetClientCredentials(ReplaceYourClientID, ReplaceYourClientSecret, ReplaceWithRefreshToken , ReplaceWithScopes);
    return clientCredentials;
}
```
This method now gives you ClientCredentialsResponse object which contains an access token.

## Using the EbaySharp

Initialize the instance with the access token.

```C#
EbayController ebayController = new EbayController(clientCredentials.AccessToken);
```

## Taxonomy

You can see a list of Taxonomy methods here https://developer.ebay.com/api-docs/commerce/taxonomy/resources/methods

### Get default category tree id

```C#
CategoryTreeIDResponse categoryTreeIDResponse = await ebayController.GetDefaultCategoryTreeIDAsync([MarketplaceID]);
```

You need to pass MarketplaceID, please visit https://developer.ebay.com/api-docs/commerce/taxonomy/static/supportedmarketplaces.html for supported market places.

### Get category suggestions

```C#
CategorySuggestionsResponse categorySuggestionsResponse = await ebayController.GetCategorySuggestionsAsync([CategoryTreeID], [ProductTitle]);
```

You need to pass a Category Tree ID and the product title you are searching categories for.

### Get category tree

```C#
CategoryTreeResponse categorySuggestionsResponse = await ebayController.GetCategoryTreeAsync([CategoryTreeID]);
```

You need to pass a Category Tree ID.

## Metadata
You can see a list of Metadata methods here https://developer.ebay.com/api-docs/sell/metadata/resources/methods

### Get return policies

```C#
ReturnPoliciesResponse returnPoliciesResponse = await ebayController.GetReturnPoliciesAsync([MarketplaceID]);
```

You need to pass MarketplaceID, please visit https://developer.ebay.com/api-docs/commerce/taxonomy/static/supportedmarketplaces.html for supported market places.
