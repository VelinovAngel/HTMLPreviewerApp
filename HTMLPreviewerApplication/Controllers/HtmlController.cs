namespace HTMLPreviewerApplication.Controllers
{

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using HTMLPreviewerApplication.Infrastructure;
    using HTMLPreviewerApplication.Models.HtmlModels;
    using HTMLPreviewerApplication.Service.HtmlSampleService;
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
                this.TempData["Message"] = "Invalid HTML sample!";
                return RedirectToAction("Index", "Home");
            }

            var size = this.htmlSampleService.MemoryResizer(sampleForm.HtmlCode);

            if(size > Size_HTML_In_Input)
            {
                this.TempData["Message"] = "Size is bigger than request! Please resize you HTML code!";
                return RedirectToAction("Index", "Home");
            }
            var userId = this.User.Id();

            var result = await this.htmlSampleService.CreateAndSave(sampleForm.HtmlCode, userId);

            if (!result)
            {
                return this.NotFound();
            }

            this.TempData["Success"] = "Html code is success saved!";
            return RedirectToAction("All", "Html");
        }


        [Authorize]
        public IActionResult All()
        {

            var userId = this.User.Id();
            var allHtmlCodes = this.htmlSampleService.All(userId);
            return this.View(allHtmlCodes);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(SampleFormModel sampleFormModel)
        {
            //var id = Url.ActionContext.RouteData.Values["id"];
            var userId = this.User.Id();

            var isExist = this.htmlSampleService.IsExist(sampleFormModel.Id, userId);
            var sampleHtml = this.htmlSampleService.HtmlCode(sampleFormModel.Id);
            if (!isExist)
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                this.TempData["Message"] = "Invalid HTML sample!";
                return RedirectToAction("Index", "Home");
            }

            var size = this.htmlSampleService.MemoryResizer(sampleHtml.Code);

            if (size > Size_HTML_In_Input)
            {
                this.TempData["Message"] = "Size is bigger than request! Please resize you HTML code!";
                return RedirectToAction("Index", "Home");
            }

            await this.htmlSampleService.EditHtmCode(new SampleFormModel { HtmlCode = sampleFormModel.HtmlCode, Id = sampleFormModel.Id});

            this.TempData["Success"] = "Html code is success saved!";
            return RedirectToAction("All", "Html");
        }
    }
}
