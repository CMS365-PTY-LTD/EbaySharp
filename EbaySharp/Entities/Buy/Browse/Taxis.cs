﻿namespace EbaySharp.Entities.Buy.Browse
{
    public class Taxis
    {
        public bool? EbayCollectAndRemitTax { get; set; }
        public bool? IncludedInPrice { get; set; }
        public bool? ShippingAndHandlingTaxed { get; set; }
        public TaxJurisdiction TaxJurisdiction { get; set; }
        public string TaxPercentage { get; set; }
        public TaxTypeEnum? TaxType { get; set; }
    }
}