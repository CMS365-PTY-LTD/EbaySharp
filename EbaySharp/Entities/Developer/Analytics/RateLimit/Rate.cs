﻿namespace EbaySharp.Entities.Developer.Analytics.RateLimit
{
    public class Rate
    {
        public int? Limit { get; set; }
        public int? Remaining { get; set; }
        public string Reset { get; set; }
        public int? TimeWindow { get; set; }
    }
}