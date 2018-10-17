using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IS4.Auth.AspNetIdentity
{
    public class AspNetIdentityDbContext : IdentityDbContext<User, Role, string>
    {
        public AspNetIdentityDbContext(DbContextOptions<AspNetIdentityDbContext> options) : base(options)
        {
            
        }

        public new DbSet<User> Users { get; set; } 
        public new DbSet<Role> Roles { get; set; }
    }
}
