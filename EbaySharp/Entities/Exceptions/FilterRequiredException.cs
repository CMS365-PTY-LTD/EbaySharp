using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Exceptions
{
    public class FilterRequiredException : Exception
    {
        public FilterRequiredException() : base("Filter is required")
        {
        }
        public string Code { get { return ExceptionCodes.FILTER_NOT_FOUND.ToString(); } }
    }
}
