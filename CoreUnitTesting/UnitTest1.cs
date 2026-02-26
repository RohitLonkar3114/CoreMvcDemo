using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;

namespace CoreUnitTesting
{
    public class UnitTest1:IClassFixture<WebApplicationFactory<Program>> // To Work With Web then inherite this class
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;    
        public UnitTest1()
        {
            _factory =new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }
        [Fact(Skip ="Skipped this test")]
        public async Task Test1()
        {
            var client = _factory.CreateClient();
            var response =await client.GetAsync("/City/Index");
            int code = (int)response.StatusCode;
            Assert.Equal(200, code);
        }
        //[Theory]
        //[InlineData("/")]
        //[InlineData("/Home")]
        //[InlineData("/Home/Privacy")]
        //[InlineData("/City/Demo")]
        //[InlineData("/City")]
        //public async Task TestPages(string url)
        //{
        //    var client = _factory.CreateClient();
        //    var response = await client.GetAsync(url);
        //    int code = (int)response.StatusCode;
        //    Assert.Equal(200, code);
        //}

        [Theory]
        [InlineData("Pune")]
        [InlineData("Mumbai")]
        [InlineData("Nashik")]
        [InlineData("Nagar")]
        [InlineData("Delhi")]
        public async Task TestCities(string city)
        {
            var response = await _client.GetAsync("/City/Index");
            var pageContent = await response.Content.ReadAsStringAsync();
            var contentString = pageContent.ToString();

            Assert.Contains(city, contentString);
        }
    }
}