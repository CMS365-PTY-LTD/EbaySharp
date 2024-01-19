namespace EbaySharp.Entities.Metadata
{
    public class ReturnPolicy
    {
        public string CategoryTreeID { get; set; }
        public string CategoryID { get; set; }
        public ReturnPolicyDestination Domestic { get; set; }
        public ReturnPolicyDestination International { get; set; }
    }
}
