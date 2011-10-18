namespace Me.Web.Mvc.Common
{
    #region using

    using System;
    using System.Web;

    #endregion

    public static class RequestExtensions
    {
        public static bool IsDev(this HttpRequest request)
        {
            Check.IsNotNull(request, "request");

            var host = request.Url.Host;

            return host.Split('.').Length > 1 && host.Substring(0, host.IndexOf(".")).Equals("dev", StringComparison.OrdinalIgnoreCase);
        }
    }
}