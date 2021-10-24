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
            }).ToList();
    }
}
