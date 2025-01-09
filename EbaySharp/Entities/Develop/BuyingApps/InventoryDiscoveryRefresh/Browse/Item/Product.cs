namespace EbaySharp.Entities.Develop.BuyingApps.InventoryDiscoveryRefresh.Browse.Item
{
    public class Product
    {
        public List<Image> AdditionalImages { get; set; }
        public List<AdditionalProductIdentity> AdditionalProductIdentities { get; set; }
        public List<AspectGroup> AspectGroups { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public List<string> Gtins { get; set; }
        public Image Image { get; set; }
        public List<string> Mpns { get; set; }
        public string Title { get; set; }
    }
}