﻿namespace EbaySharp.Source
{
    internal class Constants
    {
        internal const string SERVER_URL = "https://api.ebay.com";
        public struct COMMERCE
        {
            internal struct TAXONOMY
            {
                internal const string ENDPOINT_URL = "/commerce/taxonomy/v1";
                internal struct METHODS
                {
                    internal const string GET_DEFAULT_CATEGORY_TREE_ID = "/get_default_category_tree_id?marketplace_id={0}";
                    internal const string GET_CATEGORY_SUGGESTIONS = "/category_tree/{0}/get_category_suggestions?q={1}";
                    internal const string GET_CATEGORY_TREE = "/category_tree/{0}";
                }
            }
        }
        internal struct SELL
        {
            internal struct INVENTORY
            {
                internal const string ENDPOINT_URL = "/sell/inventory/v1";
                internal struct METHODS
                {
                    internal const string BULK_MIGRATE_LISTING = "/bulk_migrate_listing";
                    internal const string INVENTORY_ITEMS = "/inventory_item?limit={0}&offset={1}";
                    internal const string INVENTORY_ITEM = "/inventory_item/{0}";
                    internal const string OFFERS = "/offer?sku={0}";
                    internal const string OFFER = "/offer/{0}";
                    internal const string CREATE_OFFER = "/offer";
                    internal const string LOCATIONS = "/location?limit={0}&offset={1}";
                    internal const string LOCATION = "/location/{0}";
                }
            }
            internal struct METADATA
            {
                internal const string ENDPOINT_URL = "/sell/metadata/v1";
                internal struct METHODS
                {
                    internal const string GET_RETURN_POLICIES = "/marketplace/{0}/get_return_policies";
                }
            }
            internal struct FULFILLEMENT
            {
                internal const string ENDPOINT_URL = "/sell/fulfillment/v1";
                internal struct ORDER
                {
                    internal const string ENDPOINT_URL = "/order";
                    internal struct SHIPPING_FULFILLEMENT
                    {
                        internal struct METHODS
                        {
                            internal const string GET_SHIPPING_FULFILLEMENTS = "/{0}/shipping_fulfillment";
                            internal const string GET_SHIPPING_FULFILLEMENT = "/{0}/shipping_fulfillment/{1}";
                            internal const string CREATE_SHIPPING_FULFILLEMENTS = "/{0}/shipping_fulfillment";

                        }
                    }
                    internal struct METHODS
                    {
                        internal const string GET_ORDER = "/{0}";
                        internal const string GET_ORDERS_BY_ORDER_NUMBERS = "?orderIds={0}";
                        internal const string GET_ORDERS_BY_FILTER = "?filter={0}&limit={1}&offset={2}";
                    }
                }
            }
        }
        internal struct IDENTITY
        {
            internal const string ENDPOINT_URL = "/identity/v1/oauth2";
            internal struct METHODS
            {
                internal const string TOKEN = "/token";
            }
        }
        internal struct DEVELOPER
        {
            internal const string ENDPOINT_URL = "/developer";
            internal struct ANALYTICS
            {
                internal const string ENDPOINT_URL = "/analytics/v1_beta";
                internal struct METHODS
                {
                    internal const string GET_RATE_LIMITS = "/rate_limit";
                    internal const string GET_USER_RATE_LIMITS = "/user_rate_limit";
                }
            }
            
        }
    }
}
