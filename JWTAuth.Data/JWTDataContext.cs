using JWTAuth.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Data
{
    public class KabanSurveyContext : DbContext
    {
        public KabanSurveyContext(DbContextOptions<KabanSurveyContext> options) : base(options)
        {
        }

        public DbSet<Survey> Surveys { get; set; }
    }
}
