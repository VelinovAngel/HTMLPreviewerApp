namespace HTMLPreviewerApplication.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    public class HtmlController : BaseController
    {

        [Authorize]
        [HttpPost]
        public IActionResult Save()
        {
            return View();
        }
    }
}
