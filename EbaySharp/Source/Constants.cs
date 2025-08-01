﻿namespace EbaySharp.Source
{
    internal class Constants
    {
        internal const string API_SERVER_URL = "https://api.ebay.com";
        internal const string APIZ_SERVER_URL = "https://apiz.ebay.com";
        internal struct COMMERCE
        {
            internal const string ENDPOINT_URL = "/commerce";
            internal struct TAXONOMY
            {
                internal const string ENDPOINT_URL = "/taxonomy/v1";
                internal struct METHODS
                {
                    internal const string GET_DEFAULT_CATEGORY_TREE_ID = "/get_default_category_tree_id?marketplace_id={0}";
                    internal const string GET_CATEGORY_SUGGESTIONS = "/category_tree/{0}/get_category_suggestions?q={1}";
                    internal const string GET_CATEGORY_TREE = "/category_tree/{0}";
                }
            }
        }
        internal struct DEVELOP
        {
            internal struct SELLING_APPS
            {
                internal const string ENDPOINT_URL = "/sell";
                internal struct ACCOUNT_MANAGEMENT
                {
                    internal struct FINANCES
                    {
                        internal const string ENDPOINT_URL = "/finances/v1";
                        internal struct METHODS
                        {
                            internal const string GET_TRANSACTIONS = "/transaction?limit={0}&offset={1}";
                            internal const string GET_TRANSACTION_SUMMARY = "/transaction_summary";
                            internal const string GET_PAYOUT_SUMMARY = "/payout_summary";
                            internal const string GET_PAYOUTS = "/payout";
                            internal const string GET_PAYOUT = "/payout/{0}";
                        }
                    }
                }
                internal struct LISTING_MANAGEMENT
                {
                    internal struct FEED
                    {
                        internal const string ENDPOINT_URL = "/feed/v1";
                        internal struct TASK
                        {
                            internal const string ENDPOINT_URL = "/task";
                            internal struct METHODS
                            {
                                internal const string GET_DOWNLOAD_RESULT_FILE = "/{0}/download_result_file";
                            }
                        }
                        internal struct INVENTORY_TASK
                        {
                            internal const string ENDPOINT_URL = "/inventory_task";
                        }
                    }
                    internal struct INVENTORY
                    {
                        internal const string ENDPOINT_URL = "/inventory/v1";
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
                    internal struct STORES
                    {
                        internal const string ENDPOINT_URL = "/stores/v1";
                        internal struct STORE
                        {
                            internal const string ENDPOINT_URL = "/store";
                            internal struct METHODS
                            {
                                internal const string GET_STORE_CATEGORIES = "/categories";
                            }
                        }
                    }
                }
                internal struct ORDERS_MANAGEMENT
                {
                    internal struct FULFILLEMENT
                    {
                        internal const string ENDPOINT_URL = "/fulfillment/v1";
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
                internal struct LISTING_METADATA
                {
                    internal struct METADATA
                    {
                        internal const string ENDPOINT_URL = "/metadata/v1";
                        internal struct MARKETPLACE
                        {
                            internal const string ENDPOINT_URL = "/marketplace";
                            internal struct METHODS
                            {
                                internal const string GET_RETURN_POLICIES = "/{0}/get_return_policies";
                            }
                        }
                    }
                }
                internal struct OTHERS
                {
                    internal struct IDENTITY
                    {
                        internal const string GET_USER = "/commerce/identity/v1/user/";
                    }
                }
            }
        }
        internal struct AUTHENTICATION
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
            internal struct KEY_MANAGEMENT
            {
                internal const string ENDPOINT_URL = "/key_management/v1";
                internal struct METHODS
                {
                    internal const string CREATE_SIGNING_KEY = "/signing_key";
                    internal const string GET_SIGNING_KEY = "/signing_key/{0}";
                    internal const string GET_SIGNING_KEYS = "/signing_key";
                }
            }
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
        internal struct BUY
        {
            internal const string ENDPOINT_URL = "/buy";
            internal struct BROWSE
            {
                internal const string ENDPOINT_URL = "/browse/v1";
                internal struct ITEM
                {
                    internal const string ENDPOINT_URL = "/item";
                    internal struct METHODS
                    {
                        internal const string GET_ITEM = "/v1|{0}|0";
                    }
                }
            }
        }
        internal struct TRADIONAL
        {
            internal const string ENDPOINT_URL = "/ws/api.dll";
            internal struct CALLS
            {
                public const string GetSellerList = "GetSellerList";
                public const string GetAccount = "GetAccount";
            }
        }
    }
}
