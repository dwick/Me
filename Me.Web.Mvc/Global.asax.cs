namespace Me.Web.Mvc
{
    #region using

    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Diagnostics;
    
    using Elmah;
    using MvcMiniProfiler;
    using MvcMiniProfiler.MVCHelpers;

    using Common;

    #endregion

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRouteLowerCase(
                "Default",
                "{controller}/{action}/{id}", 
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        public void ErrorMail_Filtering(object sender, ExceptionFilterEventArgs e)
        {
            var httpException = e.Exception as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404 || Debugger.IsAttached)
            {
                e.Dismiss();
            }
        }

        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ProfilingViewEngine(new RazorViewEngine()));

            AreaRegistration.RegisterAllAreas();

            GlobalFilters.Filters.Add(new ProfilingActionFilter());
            GlobalFilters.Filters.Add(new HandleErrorAttribute());

            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal) { MiniProfiler.Start(); }
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }

    }
}