# EbaySharp: A .NET wrapper library for eBay REST API.
[![NuGet version](https://img.shields.io/nuget/v/CMS365.EbaySharp.svg?maxAge=3600)](https://www.nuget.org/packages/CMS365.EbaySharp/)
![GitHub last commit (main)](https://img.shields.io/github/last-commit/CMS365-PTY-LTD/EbaySharp/main.svg?logo=github)
[![NuGet Downloads](https://img.shields.io/nuget/dt/CMS365.EbaySharp.svg?logo=nuget)](https://www.nuget.org/packages/CMS365.EbaySharp/)
[![Build status](https://img.shields.io/azure-devops/build/cms-365/EbaySharp/8.svg?logo=azuredevops)](https://cms-365.visualstudio.com/EbaySharp/_build?definitionId=8)
[![license](https://img.shields.io/github/license/CMS365/EbaySharp.svg?maxAge=3600)](https://github.com/CMS365-PTY-LTD/EbaySharp/blob/master/LICENSE.txt)

EbaySharp is a .NET library that enables you to authenticate and make REST API calls to eBay. It's used for creating listings and managing orders using C# and .NET
# Installation
EbaySharp is [available on NuGet](https://www.nuget.org/packages/CMS365.EbaySharp/). Use the package manager
console in Visual Studio to install it:

```pwsh
Install-Package CMS365.EbaySharp
```
# API support

| EbaySharp version    | eBay REST API version            | Build versions     |
| -------------------- | -------------------------------- |--------------------|
| 1                    | Taxonomy Taxonomy API v1.0.1     | 0                  |

EbaySharp currently supports the following Facebook Graph APIs:

-   Getting started
    -   [Creating an app](#creating-an-app)
-   Access and Security
    -   [Getting the access token](#access-and-security)
-   Using the EbaySharp
    -   [Using the EbaySharp](#using-the-EbaySharp)
    -   [Page](#page)
        -   [Get page details](#get-page-details)
        -   [Post with multiline text and images](#post-with-multiline-text-and-images)
        -   [Post with multiline text and link](#post-with-multiline-text-and-a-link)
        -   [Get page albums](#get-page-albums)
    -   [General Graph API methods](#general-graph-api-methods)
        -   [Get](#get)

## Creating an App

Please visit https://developers.facebook.com/apps and create an app.

## Access and Security

Please visit https://developers.facebook.com/tools/explorer/ and generate a user token.

[![Generate a user token](https://i.imgur.com/a2WvGaH.png)](https://developers.facebook.com/tools/explorer/)

You can adjust permissions based on your needs. This is a short lived token and can be used for Facebook Graph api for user level operations. We will use it to generate a long live user token.

User postman and send a request to the following endpoint and get a long lived user token.

```C#
https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token&client_id=APP_CLIENT_ID&client_secret=APP_CLIENT_SECRET&fb_exchange_token=YOUR_SHORT_LIVED_USER_TOKEN_HERE
```
You will get a response like 
```C#
{
    "access_token": "vMF7UXNvRZC6m58zr0tRQJP3MVCZBd6JDhHkyCXjWcfag8hfcmjImn85B2YPZAUYK4eirj9ZA0ZAsp1TocZD",
    "token_type": "bearer",
    "expires_in": 5182228
}
```
We will get an access_token which is long lived user token and can be used for Facebook Graph api for user level operations but we have to generate a page token so that we can perform action on a Facebook page.
```C#
https://graph.facebook.com/FACEBOOK_PAGE_ID?fields=access_token&access_token=LONG_LIVED_USER_TOKEN
```

```C#
{
    "access_token": "EAASZAbmgGb7YBAFWM3uNUKan1ZBTf4rIAQiLzPSNMa7Lm3Ak1R8tNAVwsORl0LZAcPNEURzFgl6",
    "id": "111444904022049"
}
```
We have now got a page token which we will use to perform actions on a Facebook page.

## Using the EbaySharp
 Initialize the instance with the page token
```C#
var facebookController = new EbaySharp.FacebookController("EAASZAbmgGb7YBAFWM3uNUKan1ZBTf4rIAQiLzPSNMa7Lm3Ak1R8tNAVwsORl0LZAcPNEURzFgl6");
```

## Page
### Get page details
```C#
PageInfo pageInfo = await facebookController.GetPageDetailsAsync("[PAGE_ID]");
```
### Post with multiline text and images
```C#
CreateFeedResponse feedWithImages = await facebookController.PostPageFeedAsync("[PAGE_ID]", new EbaySharp.Entities.Page.PageFeedRequestContent()
{
    MessageLines = new List<string>() { "I am a test message", "I am on next line", "https://google.com" },
    PhotoUrls = new List<string>() { "https://google.com/34f4ea06a374b216cb1c778a0d1810c6_480x.jpg?v=1684836648" }
});
```
### Post with multiline text and a link
```C#
CreateFeedResponse feedWithLink = await facebookController.PostPageFeedAsync("[PAGE_ID]",new List<string>() 
{ 
    "I am a test message", "I am on next line", "I am a third line", "I am a fourth line"
},
"https://google.com");
```
### Get page albums
```C#
var pageAlbums = await facebookController.GetPageAlbumsAsync("[PAGE_ID]", string fields = "");
```
### Get page albums
Returns most recent 25 conversations.
List of fields is available at https://developers.facebook.com/tools/explorer/1294599377547190/?method=GET&path=me%2Fconversations
```C#
var pageConversations = await facebookController.GetPageConversations("[PAGE_ID]", string fields = "");
```
## General Graph API methods
You can call direct graph API method If there is no mapping available. For example
### Get
```C#
var info = await facebookController.Get("/[apge_id]?fields=name,about,link,cover");
```