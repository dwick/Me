namespace Me.Web.Mvc.Controllers
{
    #region using

    using System.Web.Mvc;

    using Helpers.Attributes;
    using Infrastructure.EntityFramework;

    #endregion
#if !DEBUG
    [RemoveHtmlWhitespace]
#endif
    public class AbstractController : Controller
    {
    }
}
