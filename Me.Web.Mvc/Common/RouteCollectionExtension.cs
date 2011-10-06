namespace Me.Web.Mvc.Common
{
    #region using

    using System.Web.Mvc;
    using System.Web.Routing;

    #endregion

    public static class RouteCollectionExtension
    {
        public static Route MapRouteLowerCase(this RouteCollection routes, string name, string url, object defaults)
        {
            return routes.MapRouteLowerCase(name, url, defaults, null);
        }

        public static Route MapRouteLowerCase(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            Check.IsNotNull(routes, "routes");
            Check.IsNotNull(url, "url");

            Route route = new LowercaseRoute(url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary(),
            };

            routes.Add(name, route);

            return route;
        }
    }
}
