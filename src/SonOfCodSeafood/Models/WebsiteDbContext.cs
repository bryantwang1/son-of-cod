using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SonOfCodSeafood.Models
{
    public class WebsiteDbContext : IdentityDbContext<WebsiteUser>
    {
        public WebsiteDbContext(DbContextOptions options) : base(options)
        {

        }

        public WebsiteDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<NewsletterMember> NewsletterMembers { get; set; }
    }
}
