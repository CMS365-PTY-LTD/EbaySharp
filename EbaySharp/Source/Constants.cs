namespace EbaySharp.Source
{
    internal class Constants
    {
        internal const string SERVER_URL = "https://api.ebay.com";
        internal struct TAXONOMY
        {
            internal const string ENDPOINT_URL = "commerce/taxonomy/v1";
            internal struct METHODS
            {
                internal const string GET_DEFAULT_CATEGORY_TREE_ID = "/get_default_category_tree_id?marketplace_id={0}";
                internal const string GET_CATEGORY_SUGGESTIONS = "/category_tree/{0}/get_category_suggestions?q={1}";
            }
        }
        internal struct IDENTITY
        {
            internal const string ENDPOINT_URL = "identity/v1/oauth2";
            internal struct METHODS
            {
                internal const string TOKEN = "token";
            }
        }
    }
}
