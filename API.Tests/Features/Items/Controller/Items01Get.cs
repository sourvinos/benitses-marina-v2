using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using API.Features.Items;
using Cases;
using Infrastructure;
using Responses;
using Xunit;

namespace Items {

    [Collection("Sequence")]
    public class Items01Get : IClassFixture<AppSettingsFixture> {

        #region variables

        private readonly AppSettingsFixture _appSettingsFixture;
        private readonly HttpClient _httpClient;
        private readonly TestHostFixture _testHostFixture = new();
        private readonly string _actionVerb = "get";
        private readonly string _baseUrl;
        private readonly string _url = "/items";

        #endregion

        public Items01Get(AppSettingsFixture appsettings) {
            _appSettingsFixture = appsettings;
            _baseUrl = _appSettingsFixture.Configuration.GetSection("TestingEnvironment").GetSection("BaseUrl").Value;
            _httpClient = _testHostFixture.Client;
        }

        [Fact]
        public async Task Unauthorized_Not_Logged_In() {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, "", "", null);
        }

        [Fact]
        public async Task Unauthorized_Invalid_Credentials() {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, "user-does-not-exist", "not-a-valid-password", null);
        }

        [Theory]
        [ClassData(typeof(InactiveUsersCanNotLogin))]
        public async Task Unauthorized_Inactive_Users(Login login) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, login.Username, login.Password, null);
        }

        [Fact]
        public async Task Admins_Can_List() {
            var actionResponse = await List.Action(_httpClient, _baseUrl, _url, "john", Helpers.AdminPassword());
            var records = JsonSerializer.Deserialize<List<ItemListVM>>(await actionResponse.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Assert.Equal(384, records.Count);
        }

    }

}