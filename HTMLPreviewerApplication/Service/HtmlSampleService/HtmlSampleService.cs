namespace HTMLPreviewerApplication.Service.HtmlSampleService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HTMLPreviewerApplication.Data;
    using HTMLPreviewerApplication.Data.Models;
    using HTMLPreviewerApplication.Models.HtmlModels;
    using HTMLPreviewerApplication.Service.Models;

    public class HtmlSampleService : IHtmlSampleService
    {
        private readonly ApplicationDbContext dbContext;

        public HtmlSampleService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public double MemoryResizer(string htmlSize)
        {
            //At the same time, practically 1 megabyte is used as 220 B, which means 1,048,576 bytes.
            //Convert byte to megabyte for check if htmlSize is > 5MB
            return (double)Encoding.Unicode.GetByteCount(htmlSize) / 1048576;
        }

        public async Task<bool> CreateAndSave(string HtmlCode, string userId)
        {
            var newHtmlSample = new HtmlSample
            {
                HtmlCode = HtmlCode,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
                UserId = userId
            };

            await this.dbContext.AddAsync(newHtmlSample);
            return await this.dbContext.SaveChangesAsync() > 0;
        }

        public IEnumerable<HtmlSampleInfo> All(string userId)
            => this.dbContext.HtmlSample
            .Where(x => x.UserId == userId)
            .Select(x => new HtmlSampleInfo
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn
            })
            .OrderByDescending(x => x.CreatedOn)
            .ThenByDescending(x=>x.ModifiedOn)
            .ToList();

        public HtmlCodeServiceModel HtmlCode(string htmlId)
            => this.dbContext.HtmlSample
            .Where(x => x.Id == htmlId)
            .Select(x => new HtmlCodeServiceModel
            {
                Id = x.Id,
                Code = x.HtmlCode
            })
            .FirstOrDefault();

        public async Task<bool> EditHtmCode(SampleFormModel sampleForm)
        {
            var htmlCode = this.dbContext.HtmlSample
                .FirstOrDefault(x => x.Id == sampleForm.Id);

            if (htmlCode == null)
            {
                return false;
            }

            htmlCode.HtmlCode = sampleForm.HtmlCode;
            htmlCode.ModifiedOn = DateTime.UtcNow;

            return await this.dbContext.SaveChangesAsync() > 0;
        }

        public bool IsExist(string htmlCodeId, string userId)
            => this.dbContext.HtmlSample.Any(x => x.Id == htmlCodeId && x.UserId == userId);

        public bool IsSame(string inputHtml)
        {
            var getAllHtml = this.dbContext.HtmlSample
                            .ToList();
            bool result = false;
            var clearInput = inputHtml.Replace("\n", "");

            foreach (var text in getAllHtml)
            {
                var textDb = text.HtmlCode.Replace(Environment.NewLine, "");
                var textCleaner = textDb.Replace("\n", "");
                var textLeng = textCleaner.Length;
                if (textCleaner != clearInput)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
