using Microsoft.Extensions.Configuration;

namespace MedicineDiary.Tests
{
    public class BaseTest
    {
        private readonly IConfigurationRoot configuration;
        protected readonly string dbConnection;

        public BaseTest()
        {
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            dbConnection = configuration["DB:ConnectionString"];
        }
    }
}