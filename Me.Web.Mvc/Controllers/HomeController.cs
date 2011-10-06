namespace Me.Web.Mvc.Controllers
{
    #region using

    using System.Web.Mvc;

    #endregion

    public class HomeController : AbstractController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
