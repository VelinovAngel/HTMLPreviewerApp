namespace HTMLPreviewerApplication.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public User()
        {
            this.HtmlSample = new HashSet<HtmlSample>();
        }

        public ICollection<HtmlSample> HtmlSample { get; init; }
    }

}
