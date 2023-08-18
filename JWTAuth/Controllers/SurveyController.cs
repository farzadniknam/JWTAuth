using JWTAuth.Data.Repositories.GeneralRepositories;
using JWTAuth.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JWTAuth.Data.Entities;

namespace JWTAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : Controller
    {
        private readonly ISurveyRepo _surveyRepo;
        private readonly ILogger<SurveyController> _logger;
        private readonly UnitOfWorkFilter _uow;


        public SurveyController(ILogger<SurveyController> logger,
                                UnitOfWorkFilter unitOfWork,
                                ISurveyRepo surveyRepo)
        {
            _logger = logger;
            _uow = unitOfWork;
            _surveyRepo = surveyRepo;
        }

        // GET ALL: api/<SurveyController>
        [HttpGet]
        public async Task<IEnumerable<Survey>?> GetAll()
        {
            var surveys = await _surveyRepo.GetAllAsync();
            return surveys;
        }

        // GET api/<SurveyController>/5
        [HttpGet("{id}")]
        public async Task<Survey?> Get(int id)
        {
            var survey = await _surveyRepo.GetAsync(1);
            return survey;
        }
    }
}
