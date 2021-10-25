namespace HTMLPreviewerApplication.Controllers.ApiController
{
    using HTMLPreviewerApplication.Data.Models;
    using HTMLPreviewerApplication.Models.ApiModel;
    using HTMLPreviewerApplication.Service.HtmlSampleService;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;

    public class CheckerController : BaseApiController
    {
        private readonly IHtmlSampleService sampleService;

        public CheckerController(IHtmlSampleService sampleService)
        {
            this.sampleService = sampleService;
        }

        [Authorize]
        [HttpPost]
        [Route("api/checker")]
        public IActionResult Post(ApiModelInput apiModelInput)
        {
            var result = this.sampleService.IsSame(apiModelInput.HtmlCode);

            if (!result)
            {
                this.ViewData["Massage"] = "Not exist!";           
            }
            else
            {
                this.ViewData["Massage"] = "Already exist!";
            }

            return new JsonResult(result);
        }

    }
}
