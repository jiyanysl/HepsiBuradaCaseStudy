using HepsiBuradaTech.CQRS.Commands.Request;
using HepsiBuradaTech.CQRS.Commands.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HepsiBuradaTech.Test
{
    public class ApiTests
    {
        [Fact]
        public async Task<Guid> CreateProductTest()
        {
            var client = new TestClientProvider().Client;
            var result = await client.PostAsJsonAsync("/api/categories",
                new CreateProductCommandRequest
                {
                    ProductCode = "test",
                    Stock = 150,
                    Price =12
                });

            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);

            var str = await result.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<CreateProductCommandResponse>(str);

            return obj.Id;
        }

    }
}
