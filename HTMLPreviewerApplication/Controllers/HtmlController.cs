namespace HTMLPreviewerApplication.Controllers
{
    using HTMLPreviewerApplication.Infrastructure;
    using HTMLPreviewerApplication.Models.HtmlModels;
    using HTMLPreviewerApplication.Service.HtmlSampleService;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using static HTMLPreviewerApplication.GlobalConstans.HtmlControllerCommon;

    public class HtmlController : BaseController
    {
        private readonly IHtmlSampleService htmlSampleService;

        public HtmlController(IHtmlSampleService htmlSampleService)
        {
            this.htmlSampleService = htmlSampleService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save(SampleFormModel sampleForm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Invalid HTML sample!";
                return RedirectToAction("Index", "Home");
            }

            var size = this.htmlSampleService.MemoryResizer(sampleForm.HtmlCode);

            if(size > Size_HTML_In_Input)
            {
                TempData["Message"] = "Size is bigger than request! Please resize you HTML code!";
                return RedirectToAction("Index", "Home");
            }
            var userId = this.User.Id();

            await this.htmlSampleService.CreateAndSave(sampleForm.HtmlCode, userId);

            TempData["Success"] = "Html code is success saved!";
            return RedirectToAction("AllHtml", "Html");
        }
    }
}
