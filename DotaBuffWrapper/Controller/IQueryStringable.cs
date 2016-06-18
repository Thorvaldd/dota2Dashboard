using System.Collections.Specialized;

namespace DotaBuffWrapper.Controller
{
    interface IQueryStringable
    {
        /// <summary>
        /// Creates the name value collection.
        /// </summary>
        /// <returns>A NameValueCollection of all public properties with their values</returns>
        NameValueCollection CreateNameValueCollection();
    }
}
