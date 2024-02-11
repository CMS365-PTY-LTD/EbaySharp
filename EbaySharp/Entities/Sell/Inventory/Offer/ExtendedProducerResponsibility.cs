using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class ExtendedProducerResponsibility
    {
        public Amount EcoParticipationFee { get; set; }
        public string ProducerProductId { get; set; }
        public string ProductDocumentationId { get; set; }
        public string ProductPackageId { get; set; }
        public string ShipmentPackageId { get; set; }
    }
}