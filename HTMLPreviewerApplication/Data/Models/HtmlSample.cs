namespace HTMLPreviewerApplication.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static HTMLPreviewerApplication.Data.ModelConstans.HtmlSimpleCommon;

    public class HtmlSample
    {
        public HtmlSample()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        [MaxLength(ID_LENGHT)]
        public string Id { get; set; }

        [Required]
        public string HtmlCode { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

    }
}
