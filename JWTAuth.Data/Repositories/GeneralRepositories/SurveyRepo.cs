using JWTAuth.Common.Helper;
using JWTAuth.Data.Entities;
using Microsoft.Extensions.Options;

namespace JWTAuth.Data.Repositories.GeneralRepositories
{
    public class SurveyRepo : Repo<Survey>, ISurveyRepo
    {
        public SurveyRepo(IOptions<AppSettings> options, UnitOfWorkFilter unitOfWorkFilter) : base(unitOfWorkFilter)
        {
        }

        
        // Implement any specific methods related to surveys here
    }
}
