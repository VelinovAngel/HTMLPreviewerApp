namespace HTMLPreviewerApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;


    public class HtmlController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
