namespace HTMLPreviewerApplication.Service.HtmlSampleService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HTMLPreviewerApplication.Models.HtmlModels;

    public interface IHtmlSampleService
    {
        double MemoryResizer(string htmlSize);

        Task<bool> CreateAndSave(string HtmlCode, string userId);

        IEnumerable<HtmlSampleInfo> All(string userId);
    }
}
