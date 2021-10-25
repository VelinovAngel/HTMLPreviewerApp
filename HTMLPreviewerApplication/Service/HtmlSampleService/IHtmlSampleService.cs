namespace HTMLPreviewerApplication.Service.HtmlSampleService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HTMLPreviewerApplication.Models.HtmlModels;
    using HTMLPreviewerApplication.Service.Models;

    public interface IHtmlSampleService
    {
        double MemoryResizer(string htmlSize);

        Task<bool> CreateAndSave(string HtmlCode, string userId);

        IEnumerable<HtmlSampleInfo> All(string userId);

        HtmlCodeServiceModel HtmlCode(string htmlId);

        Task<bool> EditHtmCode(SampleFormModel sampleForm);

        bool IsExist(string htmlCode, string userId);
    }
}
