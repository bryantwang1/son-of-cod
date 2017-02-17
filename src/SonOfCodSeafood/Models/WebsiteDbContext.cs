using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SonOfCodSeafood.Models
{
    public class WebsiteDbContext : IdentityDbContext<WebsiteUser>
    {
        public WebsiteDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
