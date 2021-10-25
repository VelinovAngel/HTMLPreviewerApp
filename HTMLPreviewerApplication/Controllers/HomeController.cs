namespace HTMLPreviewerApplication.Controllers
{
    using HTMLPreviewerApplication.Models;
    using HTMLPreviewerApplication.Models.HtmlModels;
    using HTMLPreviewerApplication.Service.HtmlSampleService;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;


    public class HomeController : Controller
    {
        private readonly IHtmlSampleService sampleService;

        public HomeController(IHtmlSampleService sampleService)
        {
            this.sampleService = sampleService;
        }

        public IActionResult Index(string id)
        {
            var sampleHtml = this.sampleService.HtmlCode(id);
            if(sampleHtml != null)
            {
                return this.View(new SampleFormModel { HtmlCode = sampleHtml.Code, Id = id });
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
