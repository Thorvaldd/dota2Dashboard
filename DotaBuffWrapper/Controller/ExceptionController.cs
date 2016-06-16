using System.Net;
using DotaBuffWrapper.Exceptions;

namespace DotaBuffWrapper.Controller
{
    internal class ExceptionController
    {
        internal ExceptionController()
        {
            
        }

        internal void HandleWebException(string customMessage, WebException webException)
        {
            if (webException.Status == WebExceptionStatus.ProtocolError && webException.Response != null)
            {
                HttpWebResponse errorResponse = (HttpWebResponse)webException.Response;

                if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new PlayerNotFoundException(customMessage, webException);
                }
            }
        }
    }
}
