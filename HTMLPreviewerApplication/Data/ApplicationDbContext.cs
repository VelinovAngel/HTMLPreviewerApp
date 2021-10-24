namespace HTMLPreviewerApplication.Data
{
    using HTMLPreviewerApplication.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;


    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HtmlSample> HtmlSample { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<HtmlSample>()
                .HasOne(s => s.User)
                .WithMany(u => u.HtmlSample)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
