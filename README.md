# JSON Web Token Authentication In RESTful Api .Net Core 7.0

In this article, we will delve into the creation of a compelling web application utilizing .NET 7.0 and ASP.NET Core, all while orchestrating the implementation of the powerful JWT Authentication.
I have meticulously addressed even the minutest details in this article. I am fully aware of your familiarity with most of these topics, but I aimed to highlight elements that drew my attention throughout the project. 
JWT (JSON Web Token) authentication stands as a paramount authentication mechanism dominating contemporary web applications and APIs. It reigns as a succinct, self-contained conduit for exchanging information within parties through a JSON object. Within the realm of .NET Core, the tenets of JWT authentication gain prominence as a shield for APIs, empowering users and clients to seamlessly authenticate and attain authorized entry to safeguarded resources.
Here's an overview of JWT authentication in .NET Core:
1.	Token Generation
2.	Token Structure
3.	Token Usage
4.	Token Validation
5.	Middleware and Libraries
6.	Benefits of JWT
7.	Security Considerations

Orverviews
1. Token Generation:
JWT tokens are created and signed by the server.
The token includes claims (key-value pairs) that provide information about the user, their roles, permissions, and more.
The token is typically signed with a secret key or a private key if using asymmetric cryptography.

2. Token Structure:
A JWT token consists of three parts: 
•	header, 
•	payload (claims), and 
•	signature.
These parts are base64 encoded and concatenated with periods.
The header typically contains the token type ("typ": "JWT") and the signing algorithm used ("alg": "HS256" for HMAC SHA-256).
The payload contains the claims that define user attributes and access rights.

3. Token Usage:
The token is sent to the client after successful authentication.
The client includes the token in the Authorization header of subsequent requests as a Bearer token ("Authorization: Bearer <token>").
The server validates the token's signature and checks its claims to authorize the user's access to specific resources.

4. Token Validation:
The server validates the token using the same secret key or public key used for signing.
The server checks the token's signature, expiration (exp claim), and issuer (iss claim) among other claims.
Clock skew may be used to account for differences between server and token creation times.

5. Middleware and Libraries:
ASP.NET Core provides middleware (Microsoft.AspNetCore.Authentication.JwtBearer) to handle JWT authentication.
You configure the middleware with the necessary settings and validations.

6. Benefits of JWT:
Stateless: No need to store tokens on the server side, making it scalable.
Self-contained: All the necessary information is included in the token itself.
Widely supported: JWT is a standardized format used across different platforms.

7. Security Considerations:
Store secrets securely and protect against token leakage.
Use HTTPS to encrypt communication.
Limit the amount of sensitive information stored in the token.
Here's a high-level example of how JWT authentication is configured in ASP.NET Core:

 

Within the realm of the API, I am poised to infuse my Authorization Model, injecting a robust layer of control. Notably, for this project, I have introduced a straightforward User Entity. It's worth acknowledging that in a genuine project, the AspNetUser Authentication entities would naturally come to the fore.

Following the orchestration of a seamlessly flowing RESTful API, my trajectory leads me to introduce a ClassLibrary project, dedicated to crafting the Data Layer project. Within this domain, the canvas becomes adorned with Entities and Repositories, gracefully complemented by the UnitOfWorkFilter class, a component whose significance I shall demystify in an upcoming article. The final touch is the Context, weaving together the fabric of this data-driven symphony.
In the JWTAuth API Project, as vividly demonstrated in the image below, I have strategically incorporated the AuthorizationContext. This addition serves the purpose of enabling user creation from the API into the database, employing the potent code-first technique. 

1. Token Generation:
JWT tokens are created and signed by the server.
The token includes claims (key-value pairs) that provide information about the user, their roles, permissions, and more.
The token is typically signed with a secret key or a private key if using asymmetric cryptography.

2. Token Structure:
A JWT token consists of three parts: 
•	header, 
•	payload (claims), and 
•	signature.
These parts are base64 encoded and concatenated with periods.
The header typically contains the token type ("typ": "JWT") and the signing algorithm used ("alg": "HS256" for HMAC SHA-256).
The payload contains the claims that define user attributes and access rights.

3. Token Usage:
The token is sent to the client after successful authentication.
The client includes the token in the Authorization header of subsequent requests as a Bearer token ("Authorization: Bearer <token>").
The server validates the token's signature and checks its claims to authorize the user's access to specific resources.

4. Token Validation:
The server validates the token using the same secret key or public key used for signing.
The server checks the token's signature, expiration (exp claim), and issuer (iss claim) among other claims.
Clock skew may be used to account for differences between server and token creation times.

5. Middleware and Libraries:
ASP.NET Core provides middleware (Microsoft.AspNetCore.Authentication.JwtBearer) to handle JWT authentication.
You configure the middleware with the necessary settings and validations.

6. Benefits of JWT:
Stateless: No need to store tokens on the server side, making it scalable.
Self-contained: All the necessary information is included in the token itself.
Widely supported: JWT is a standardized format used across different platforms.

7. Security Considerations:
Store secrets securely and protect against token leakage.
Use HTTPS to encrypt communication.
Limit the amount of sensitive information stored in the token.

Here's a high-level example of how JWT authentication is configured in ASP.NET Core
![image](https://github.com/farzadniknam/JWTAuth/assets/45637787/4a3c1f35-1b78-42c7-a25d-1b95f039366e)
![image](https://github.com/farzadniknam/JWTAuth/assets/45637787/7bd95a97-8ae7-4604-9133-6842370efd80)

Within the realm of the API, I am poised to infuse my Authorization Model, injecting a robust layer of control. Notably, for this project, I have introduced a straightforward User Entity. It's worth acknowledging that in a genuine project, the AspNetUser Authentication entities would naturally come to the fore.

Following the orchestration of a seamlessly flowing RESTful API, my trajectory leads me to introduce a ClassLibrary project, dedicated to crafting the Data Layer project. Within this domain, the canvas becomes adorned with Entities and Repositories, gracefully complemented by the UnitOfWorkFilter class, a component whose significance I shall demystify in an upcoming article. The final touch is the Context, weaving together the fabric of this data-driven symphony.
In the JWTAuth API Project, as vividly demonstrated in the image below, I have strategically incorporated the AuthorizationContext. This addition serves the purpose of enabling user creation from the API into the database, employing the potent code-first technique. 

Migration Authentication Entities
In our determined pursuit of this objective, the installation of the subsequent NuGet Packages becomes imperative. It's noteworthy that I am utilizing PostgreSQL in this context.
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Npgsql.EntityFrameworkCore.PostgreSQL
Microsoft.EntityFrameworkCore.Post
Microsoft.AspNetCore.Authentication.JwtBearer

For making first migration for authentication entities we must put our PostgreSQL connection string inside appsettings.json as below
```ruby
"ConnectionStrings": {
    "SurveyConnectionString": "Host=localhost;Port=5432;Database=SurveyAuth;Username=postgres;Password=*****;"
  },
"AppSettings": {
    "SomeSetting": "SomeValue",
    "AnotherSetting": "AnotherValue",
    "ConnectionString": "Host=localhost;Port=5432;Database=SurveyAuth;Username=postgres;Password=*****;"
  },
```
  
In the subsequent steps, as we proceed with the installation of the required NuGet packages and input the necessary requirements into the appsettings.json file, we will also incorporate Dependency Injection for our DataContext.
To enhance the readability of the program code, I've organized the content into separate classes and integrated them into Program.cs. The structure of my project is as follows:
![image](https://github.com/farzadniknam/JWTAuth/assets/45637787/66c9416d-fdc9-4e90-8723-5b518965b4d5)

```ruby
Helpers Folder
```
Contains various helper classes.
ConfigHelper.cs
Is a provider class designed to facilitate the addition of DbContext and other services through Dependency Injection (DI)

```ruby
using JWTAuth.Extensions;
using JWTAuth.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace JWTAuth.Helpers
{
    public class ConfigHelper
    {
        public static void ConfigureService(WebApplicationBuilder builder)
        {
            var serviceProvider = builder.Services.AddOptions().Configure<AppSettings>(builder.Configuration.GetSection("AppSettings")).BuildServiceProvider();

            // Set the value in AppSettings
            var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;

            // Add your DbContext and other services here
            builder.Services.AddDbContext<AuthorizeContexts>(options =>
                            options.UseNpgsql(appSettings.ConnectionString));

            builder.Services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();

            serviceProvider.Dispose();
      PostgreSqlBootstrap.Initialize();

     // After the creation of SurveyRepo in the DataLayer project, it is essential to add this line
      builder.Services.AddScoped<ISurveyRepo, SurveyRepo>();
            builder.Services.UseOneTransactionPerHttpCall(appSettings);

        }
    }
}
```

Services Folder
Houses all the custom services required for Dependency Injection (DI) within the solution.
```ruby
IConnectionStringProvider.cs
namespace JWTAuth.Services
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }
}
```

ConnectionStringProvider.cs
```ruby
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
```

Extensions Folder
Includes extension classes.
ServiceCollectionExtensions.cs
This extension for the service collection manages the state of connections and transactions per HttpCall for PostgreSQL.
```ruby
using JWTAuth.Helpers;
using JWTAuth.Services;
using Npgsql;
using System.Data;

namespace JWTAuth.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void UseOneTransactionPerHttpCall(this IServiceCollection serviceCollection, AppSettings _appSettings, IsolationLevel level = IsolationLevel.ReadUncommitted)
        {

            serviceCollection.AddScoped<IDbTransaction>(serviceProvider =>
{
    var connectionStringProvider = serviceProvider.GetService<IConnectionStringProvider>();
    var connection = new NpgsqlConnection(_appSettings.ConnectionString);

    if (connection.State != ConnectionState.Open)
        connection.Open();

    return connection.BeginTransaction(level);
});

serviceCollection.AddScoped(typeof(UnitOfWorkFilter), typeof(UnitOfWorkFilter));

serviceCollection.AddMvc(setup =>
{
    setup.Filters.AddService<UnitOfWorkFilter>(1);
});
        }
    }
}
```

Invoking ConfigHelper.ConfigureService(builder) within Program.cs
```ruby
var builder = WebApplication.CreateBuilder(args);
ConfigHelper.ConfigureService(builder);
```
JWTAuth.Common Project
Furthermore, we require an AppSettings.cs file, which we will place within a new class liberary project named JWTAuth.Common. This project serves as a repository for all common classes.

Helpers Folder
Contains various helper classes.
AppSettings.cs
This entity serves as a container for carrying configuration information throughout the solution.
```ruby
namespace JWTAuth.Common.Helper
{
    public class AppSettings
    {
        // Define your application settings properties here
        public string ConnectionString { get; set; }
        // ... other settings
    }
}
```

The moment has come to migrate the authentication entities to PostgreSQL and generate corresponding tables. You can choose between utilizing the 'Package Manager Console' or 'Developer PowerShell.' To proceed, right-click on the intended project and select the 'Open Terminal' option.



Migration can be initiated by executing the following command:
dotnet ef migrations add 'AuthFirstMigration'
