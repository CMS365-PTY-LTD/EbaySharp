using EbaySharp.Entities.TraditionalSelling.Trading;
using EbaySharp.Source;
using System.Text;
using System.Xml.Linq;

namespace EbaySharp.Controllers
{
    class TradingController
    {
        private string accessToken;
        public TradingController(string accessToken)
        {
            this.accessToken = accessToken;
        }
        public async Task<GetSellerListResponse> GetItems(int siteId, int pageNumber, int entriesPerPage, string endTimeFrom, string endTimeTo)
        {
            XNamespace ns = "urn:ebay:apis:eBLBaseComponents";
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(ns + "GetSellerListRequest", new XAttribute("xmlns", ns),
                    new XElement("RequesterCredentials",
                        new XElement("eBayAuthToken", accessToken)
                    ),
                    new XElement("GranularityLevel", "Coarse"),
                    new XElement("EndTimeFrom", endTimeFrom),
                    new XElement("EndTimeTo", endTimeTo),
                    new XElement("Pagination",
                        new XElement("EntriesPerPage", entriesPerPage),
                        new XElement("PageNumber", pageNumber)
                    )
                )
            );
            var memory = new MemoryStream();
            xmlDocument.Save(memory);
            string xmlText = Encoding.UTF8.GetString(memory.ToArray()).Replace("xmlns=\"\"", "");

            return await new RequestExecuter().ExecuteLegacyPostRequest<GetSellerListResponse>(siteId, Constants.TRADIONAL.CALLS.GetSellerList, xmlText);
        }
    }
}
