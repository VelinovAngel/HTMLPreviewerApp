namespace HTMLPreviewerApplication.Models.HtmlModels
{
    using System.ComponentModel.DataAnnotations;

    public class SampleFormModel
    {
        public string Id { get; init; }

        [Required]
        public string HtmlCode { get; set; }
    }
}
