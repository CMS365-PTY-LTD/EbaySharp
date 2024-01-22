﻿namespace EbaySharp.Entities.Inventory
{
    public class BulkMigrateListingWarning
    {
        public string Category { get; set; }
        public string Domain { get; set; }
        public string ErrorID { get; set; }
        public List<string> InputRefIDs { get; set; }
        public string LongMessage { get; set; }
        public string Message { get; set; }
        public List<string> OutputRefIDs { get; set; }
        public List<KeyValuePair<string, string>> Parameters { get; set; }
        public string Subdomain { get; set; }
    }
}