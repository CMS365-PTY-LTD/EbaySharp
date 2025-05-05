using EbaySharp.Controllers;
using EbaySharp.Entities.Identity;
using Microsoft.Extensions.Configuration;

namespace EbaySharp.Tests
{
    public class EbaySharpTests
    {
        private EbayController ebayController;
        private string accessToken = "";
        private IConfiguration Configuration { get; }
        public EbaySharpTests()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<EbaySharpTests>();
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
        public void Test_AccessToken()
        {
            Assert.That(string.IsNullOrEmpty(accessToken) == false);
        }
    }
}
