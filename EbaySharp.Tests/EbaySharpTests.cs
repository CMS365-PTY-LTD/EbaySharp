using EbaySharp.Controllers;
using EbaySharp.Entities.Common;
using EbaySharp.Entities.Develop.ApplicationSettingsInsights.Analytics.RateLimit;
using EbaySharp.Entities.Develop.KeyManagement.SigningKey;
using EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.Payout;
using EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.Transaction;
using EbaySharp.Entities.Develop.SellingApps.Identity.User;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Feed.Task;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.InventoryItem;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Location;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Offer;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Stores.Store;
using EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order;
using EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order.ShippingFulfillment;
using EbaySharp.Entities.Develop.SellingApps.SellingMetadata.Metadata.Marketplace;
using EbaySharp.Entities.Develop.Taxonomy;
using EbaySharp.Entities.Identity;
using EbaySharp.Entities.TraditionalSelling.Trading.GetAccount;
using EbaySharp.Entities.TraditionalSelling.Trading.GetSellerList;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Xml.Linq;

namespace EbaySharp.Tests
{
    public class EbaySharpTests
    {
        private EbayController ebayController;
        private string accessToken = "";
        private IConfiguration Configuration { get; }
        public EbaySharpTests()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<EbaySharpTests>().AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        [SetUp]
        public async Task Setup()
        {
            AuthenticationController authenticationController = new();
            ClientCredentials clientCredentials = await authenticationController.GetClientCredentials(Configuration["clientId"]
                , Configuration["clientSecret"]
                , Configuration["refreshToken"]
                , "https://api.ebay.com/oauth/api_scope https://api.ebay.com/oauth/api_scope/sell.marketing.readonly https://api.ebay.com/oauth/api_scope/sell.marketing https://api.ebay.com/oauth/api_scope/sell.inventory.readonly https://api.ebay.com/oauth/api_scope/sell.inventory https://api.ebay.com/oauth/api_scope/sell.account.readonly https://api.ebay.com/oauth/api_scope/sell.account https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly https://api.ebay.com/oauth/api_scope/sell.fulfillment https://api.ebay.com/oauth/api_scope/sell.analytics.readonly https://api.ebay.com/oauth/api_scope/sell.finances https://api.ebay.com/oauth/api_scope/sell.payment.dispute https://api.ebay.com/oauth/api_scope/commerce.identity.readonly https://api.ebay.com/oauth/api_scope/sell.reputation https://api.ebay.com/oauth/api_scope/sell.reputation.readonly https://api.ebay.com/oauth/api_scope/commerce.notification.subscription https://api.ebay.com/oauth/api_scope/commerce.notification.subscription.readonly https://api.ebay.com/oauth/api_scope/sell.stores https://api.ebay.com/oauth/api_scope/sell.stores.readonly");
            accessToken = clientCredentials.AccessToken;
            ebayController = new EbayController(accessToken);
        }
        [Test]
        public void Test_AccessTokenNotEmpty()
        {
            Assert.That(string.IsNullOrEmpty(accessToken) == false);
        }
        [Test]
        [Ignore("Ignoring Test_WithdrawOffers")]
        public async Task Test_WithdrawOffers()
        {
            var listOfItems = new List<string>() { };
            //var config = CommonUtilities.GetBadDataCSVConfiguration(true);
            //using (var reader = new StreamReader("Book1.csv"))
            //using (var csv = new CsvReader(reader, config))
            //{
            //    listOfItems = csv.GetRecords<eBayLiveItem>().Select(x => x.SKU).ToList();
            //}
            foreach (var item in listOfItems)
            {
                try
                {
                    TestContext.Progress.WriteLine($"Ending {item}");
                    var offers = await ebayController.GetOffers(item);
                    var result = await ebayController.WithdrawOffer(offers?.OfferList?.FirstOrDefault()?.OfferId);
                    TestContext.Progress.WriteLine("Ended");
                }
                catch (Exception ex)
                {
                    TestContext.Progress.WriteLine(ex.Message);
                }
            }
            Assert.That(string.IsNullOrEmpty(accessToken) == false);
        }
        [Test]
        public async Task Test_Analytics()
        {
            try
            {
                RateLimits rateLimits = await ebayController.GetRateLimits();
                Assert.That(rateLimits, Is.Not.Null);
                rateLimits = await ebayController.GetUserRateLimits();
                Assert.That(rateLimits, Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
        [Test]
        public async Task Test_Browse()
        {
            try
            {
                EbaySharp.Entities.Develop.BuyingApps.InventoryDiscoveryRefresh.Browse.Item.Item item = await ebayController.GetItem("236045446660");
                Assert.That(item, Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
        [Test]
        [Ignore("Ignoring Test_Feeds")]
        public async Task Test_Feeds()
        {
            try
            {
                ResultFile resultFile = await ebayController.GetResultFile("task-10-11171747566");
                Assert.That(resultFile, Is.Not.Null);
                await resultFile.SaveUncompressed("C:\\Work");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
        [Test]
        public async Task Test_Finances()
        {
            try
            {
                //FOR EU
                //SigningKey signingKey = await ebayController.CreateSigningKey(SigningKeyCipher.ED25519);
                //Transactions transactions = await ebayController.GetTransactions(signingKey, "payoutId:{6844384214}");
                //Assert.That(transactions, Is.Not.Null);
                //TransactionSummary transactionSummary = await ebayController.GetTransactionSummary(signingKey, "transactionStatus:{PAYOUT}");
                //Assert.That(transactionSummary, Is.Not.Null);
                //PayoutSummary payoutSummary = await ebayController.GetPayoutSummary(signingKey, "payoutDate:[2025-02-01T00:00:01.000Z..2025-03-20T00:00:01.000Z]");
                //Assert.That(payoutSummary, Is.Not.Null);
                //PayoutList payoutList = await ebayController.GetPayouts(signingKey, "payoutStatus:{SUCCEEDED}");
                //Assert.That(payoutList, Is.Not.Null);
                //Payout payout = await ebayController.GetPayout(signingKey, 6844384214);
                //Assert.That(payout, Is.Not.Null);

                //for AU

                Transactions transactions = await ebayController.GetTransactions();
                Assert.That(transactions, Is.Not.Null);
                TransactionSummary transactionSummary = await ebayController.GetTransactionSummary("transactionStatus:{PAYOUT}");
                Assert.That(transactionSummary, Is.Not.Null);
                PayoutSummary payoutSummary = await ebayController.GetPayoutSummary($"payoutDate:[{DateTime.Now.AddDays(-20).ToString("yyyy-MM-dd")}T00:00:01.000Z..{DateTime.Now.ToString("yyyy-MM-dd")}T00:00:01.000Z]");
                Assert.That(payoutSummary, Is.Not.Null);
                PayoutList payoutList = await ebayController.GetPayouts("payoutStatus:{SUCCEEDED}");
                Assert.That(payoutList, Is.Not.Null);
                Payout payout = await ebayController.GetPayout(long.Parse(payoutList.Payouts.First().PayoutId));
                Assert.That(payout, Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
        [Test]
        public async Task Test_Fulfillments()
        {
            try
            {
                string dateFormat = "yyyy-MM-ddThh:mm:00.0Z";
                string dateRange = $"{(DateTime.UtcNow.AddDays(-10).ToString(dateFormat))}..{(DateTime.UtcNow.AddHours(-2).ToString(dateFormat))}";
                Orders orders = await ebayController.GetOrders($"creationdate:[{dateRange}]", 50);
                Assert.That(orders.OrderList != null, Is.True);

                Order? order = orders.OrderList?.FirstOrDefault(x => x.OrderFulfillmentStatus == OrderFulfillmentStatus.FULFILLED);
                if (order != null)
                {
                    Fulfillments fulfillments = await ebayController.GetShippingFulfillments(order.OrderId);
                    Assert.That(fulfillments.FulfillmentItemList != null, Is.True);
                    Fulfillment? fulfillment = fulfillments.FulfillmentItemList?.FirstOrDefault();
                    if (fulfillment != null)
                    {
                        fulfillment = await ebayController.GetShippingFulfillment(order.OrderId, fulfillment.FulfillmentId);
                        Assert.That(fulfillments.FulfillmentItemList != null, Is.True);
                    }
                }
                orders = await ebayController.GetOrders($"lastmodifieddate:[{dateRange}]");
                Assert.That(orders.OrderList != null, Is.True);

                orders = await ebayController.GetOrders("orderfulfillmentstatus:{NOT_STARTED|IN_PROGRESS}");
                Assert.That(orders.OrderList != null, Is.True);

                if (orders.OrderList != null)
                {
                    orders = await ebayController.GetOrders([string.Join(',', orders.OrderList.Take(2).Select(x => x.OrderId))]);
                    Assert.That(orders.OrderList != null, Is.True);
                }

                string? orderId = orders.OrderList?.FirstOrDefault()?.OrderId;
                if (string.IsNullOrEmpty(orderId) == false)
                {
                    order = await ebayController.GetOrder(orderId);
                    Assert.That(order != null, Is.True);
                }

                //await ebayController.CreateShippingFulfillment(orderId, new Fulfillment()
                //{
                //    ShippedDate = DateTime.UtcNow.ToString(dateFormat),
                //    ShippingCarrierCode="asadsds",
                //    TrackingNumber="sa"
                //});

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
        [Test]
        public async Task Test_Inventory()
        {
            try
            {

                string SKU = "AWN-B-ARM-REMOTE-25X20-GREY";
                string merchantLocationKey = "au_vic";

                InventoryLocations inventoryLocations = await ebayController.GetInventoryLocations(200, 0);

                //foreach (var inventoryLocationItem in inventoryLocations?.Locations?.Where(x => x.MerchantLocationKey != "US_91505" && x.MerchantLocationKey != "AU_3000"))
                //{
                //    await ebayController.DeleteInventoryLocation(inventoryLocationItem.MerchantLocationKey);
                //}

                //await ebayController.CreateInventoryLocation(new InventoryLocation()
                //{
                //    MerchantLocationKey = merchantLocationKey,
                //    LocationTypes = new List<StoreTypeEnum>() { StoreTypeEnum.WAREHOUSE },
                //    MerchantLocationStatus = StatusEnum.ENABLED,
                //    Location = new Location()
                //    {
                //        Address = new Address()
                //        {
                //            PostalCode = "3698",
                //            Country = CountryCodeEnum.AU
                //        }
                //    }
                //});
                InventoryLocation inventoryLocation = await ebayController.GetInventoryLocation(merchantLocationKey);


                InventoryItems inventoryItems = await ebayController.GetInventoryItems(200, 0);

                Dictionary<string, string[]> aspects = new()
                {
                    { "Brand", new[] { "GoPro" } },
                    { "Type", new[] { "Helmet/Action" } },
                    { "Set Includes", new[] { "See description" } },
                    { "Number of Items in Set", new[] { "See description" } }

                };
                //https://developer.ebay.com/api-docs/static/rest-request-components.html#marketpl
                //await ebayController.CreateOrReplaceInventoryItem(SKU, new InventoryItem()
                //{
                //    Availability = new Availability() { ShipToLocationAvailability = new ShipToLocationAvailability() { Quantity = 3 } },
                //    Condition = ConditionEnum.NEW,
                //    Product = new inventory.InventoryItem.Product()
                //    {
                //        Title = "ZNTS GoPro Hero4 Helmet Cam",
                //        Description = "I am created by the REST API",
                //        Aspects = aspects,
                //        Brand = "GoPro",
                //        MPN = "CHDHX-401",
                //        ImageUrls = new[] { "https://i.ebayimg.com/images/g/OKsAAOSwr2VlsUPx/s-l1600.jpg", "https://i.ebayimg.com/images/g/a9AAAOSw2IVlsUPz/s-l1600.jpg" }
                //    },
                //    Locale = "en-AU"
                //});
                InventoryItem inventoryItem = await ebayController.GetInventoryItem(SKU);
                //try
                //{
                //    Offers offers = await ebayController.GetOffers(SKU);
                //    foreach (var oldOffer in offers.OfferList)
                //    {
                //        //await ebayController.DeleteOffer(oldOffer.OfferId);
                //    }
                //}
                //catch (Exception ex)
                //{

                //}

                //Offer offer = new Offer()
                //{
                //    SKU = SKU,
                //    MarketplaceId = MarketplaceEnum.EBAY_AU,
                //    Format = FormatTypeEnum.FIXED_PRICE,
                //    PricingSummary = new inventory.Offer.PricingSummary()
                //    {
                //        Price = new Amount()
                //        {
                //            Currency = CurrencyCodeEnum.AUD,
                //            Value = "75"
                //        }
                //    },
                //    MerchantLocationKey = inventoryLocation.MerchantLocationKey,
                //    CategoryId = "162480",
                //    ListingPolicies = new ListingPolicies()
                //    {
                //        FulfillmentPolicyId = "179248384024",
                //        PaymentPolicyId = "178488013024",
                //        ReturnPolicyId = "214667142024"
                //    }
                //};
                //OfferCreated offerCreated = await ebayController.CreateOffer(offer, "en-AU");

                var offer = (await ebayController.GetOffers(SKU)).OfferList.First();
                offer = await ebayController.GetOffer(offer.OfferId);
                //offer.PricingSummary.Price.Value = "100";
                //await ebayController.UpdateOffer(offer.OfferId, offer, "en-AU");
                //Assert.That(offer.Status == OfferStatusEnum.UNPUBLISHED, Is.True);
                //OfferPublished offerPublished = await ebayController.PublishOffer(offer.OfferId, "en-AU");
                Assert.That(offer.Status == OfferStatusEnum.PUBLISHED, Is.True);

                //await ebayController.WithdrawOffer(offer.OfferId);
                //await ebayController.DeleteOffer(offer.OfferId);
                //await ebayController.DeleteInventoryItem(SKU);
                //await ebayController.DeleteInventoryLocation(merchantLocationKey);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
        [Test]
        public async Task Test_Legacy_Sellers_List()
        {
            try
            {
                for (int i = 1; i < 2; i++)
                {
                    GetSellerListResponse getSellerListResponse = await ebayController.GetItems(15, i, 200, DateTime.Now.AddDays(-87).ToString("O"), DateTime.Now.AddDays(33).ToString("O"));
                    Assert.That(getSellerListResponse.ItemArray, Is.Not.Null);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
        [Test]
        public async Task Test_Legacy_Account_List()
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
        [Test]
        [Ignore("Ignore test Test_Key_Management")]
        public async Task Test_Key_Management()
        {
            try
            {

                // Required for UK only, otherwise will fail
                SigningKeys signingKeys = await ebayController.GetSigningKeys();
                Assert.That(signingKeys.SigningKeyList != null);
                SigningKey? signingKey = null;
                if (signingKeys.SigningKeyList != null)
                {
                    signingKey = await ebayController.GetSigningKey(signingKeys.SigningKeyList.First().SigningKeyId);
                    Assert.That(signingKey != null);
                    signingKey = await ebayController.CreateSigningKey(SigningKeyCipher.ED25519);
                    Assert.That(signingKey != null);
                }
                Transactions? transactions = null;

                List<Transaction> allTransactions = new List<Transaction>();

                int pageNumber = 0, recordsPerPage = 1000;
                do
                {
                    transactions = await ebayController.GetTransactions(signingKey, null, null, recordsPerPage, pageNumber * recordsPerPage);
                    allTransactions.AddRange(transactions.TransactionList);
                    ++pageNumber;
                } while (string.IsNullOrEmpty(transactions.Next) == false);

                Assert.That(transactions.TransactionList != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
        [Test]
        public async Task Test_Metadata()
        {
            try
            {
                ReturnPolicies returnPolicies = await ebayController.GetReturnPolicies("EBAY_AU");
                Assert.That(returnPolicies, Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public async Task Test_Stores()
        {
            try
            {
                StoreCategories storeCategories = await ebayController.GetStoreCategories();
                Assert.That(storeCategories, Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
        [Test]
        public async Task Test_User()
        {
            try
            {
                User user = await ebayController.GetUser();
                Assert.That(user, Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public async Task Test_Taxonomy()
        {
            try
            {
                CategoryTreeId categoryTreeIDMotorsUS = await ebayController.GetDefaultCategoryTreeId(MarketplaceIdEnum.EBAY_MOTORS_US);
                Assert.That(string.IsNullOrEmpty(categoryTreeIDMotorsUS.TreeId) == false && string.IsNullOrEmpty(categoryTreeIDMotorsUS.CategoryTreeVersion) == false);

                CategoryTreeId categoryTreeIDUS = await ebayController.GetDefaultCategoryTreeId(MarketplaceIdEnum.EBAY_US);
                Assert.That(string.IsNullOrEmpty(categoryTreeIDUS.TreeId) == false && string.IsNullOrEmpty(categoryTreeIDUS.CategoryTreeVersion) == false);

                CategoryTreeId categoryTreeIDAU = await ebayController.GetDefaultCategoryTreeId(MarketplaceIdEnum.EBAY_AU);
                Assert.That(string.IsNullOrEmpty(categoryTreeIDAU.TreeId) == false && string.IsNullOrEmpty(categoryTreeIDAU.CategoryTreeVersion) == false);

                CategoryTree categoryTree = await ebayController.GetCategoryTree(categoryTreeIDMotorsUS.TreeId);
                Assert.That(categoryTree.RootCategoryNode != null);

                categoryTree = await ebayController.GetCategoryTree(categoryTreeIDUS.TreeId);
                Assert.That(categoryTree.RootCategoryNode != null);

                categoryTree = await ebayController.GetCategoryTree(categoryTreeIDAU.TreeId);
                Assert.That(categoryTree.RootCategoryNode != null);

                CategorySuggestions categorySuggestions = await ebayController.GetCategorySuggestions(categoryTreeIDMotorsUS.TreeId, "ZNTS 2 PCS SHOCK ABSORBER Hyundai Elantra 2011-2016 15983347");
                Assert.That(categorySuggestions.CategorySuggestionList != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
    }
}
