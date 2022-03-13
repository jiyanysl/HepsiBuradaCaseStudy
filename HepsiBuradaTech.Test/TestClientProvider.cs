using System.Net.Http;

namespace HepsiBuradaTech.Test
{
    public class TestClientProvider
    {
    public HttpClient Client { get; }
        public TestClientProvider()
        {
            var application = new WebApplicationFactory<Program>()
          .WithWebHostBuilder(builder =>
          {
                // ... Configure test services
            });

            Client = application.CreateClient();
        }

    }
}
