namespace HTMLPreviewerApplication.Controllers.ApiController
{
    using HTMLPreviewerApplication.Data.Models;
    using HTMLPreviewerApplication.Models.ApiModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;

    public class CheckerController : BaseApiController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public CheckerController(UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Authorize]
        [HttpPost]
        [Route("api/checker")]
        public IActionResult Post(ApiModelInput apiModelInput)
        {
          

            return Json(new { status = "success" });
        }

    }
}
