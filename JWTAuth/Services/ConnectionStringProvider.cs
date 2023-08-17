namespace JWTAuth.Services
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            var connectionString = _configuration.GetConnectionString("SurveyConnectionString");
            return connectionString;
        }
    }
}
