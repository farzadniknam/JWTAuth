using JWTAuth.Authorization.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth
{
    public class AuthorizeContexts : DbContext
    {
        public AuthorizeContexts(DbContextOptions<AuthorizeContexts> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
