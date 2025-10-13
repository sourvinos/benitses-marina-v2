using Cases;
using Infrastructure;
using Responses;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Items {

    [Collection("Sequence")]
    public class Items05Put : IClassFixture<AppSettingsFixture> {

        #region variables

        private readonly AppSettingsFixture _appSettingsFixture;
        private readonly HttpClient _httpClient;
        private readonly TestHostFixture _testHostFixture = new();
        private readonly string _actionVerb = "put";
        private readonly string _baseUrl;
        private readonly string _url = "/items";

        #endregion

        public Items05Put(AppSettingsFixture appsettings) {
            _appSettingsFixture = appsettings;
            _baseUrl = _appSettingsFixture.Configuration.GetSection("TestingEnvironment").GetSection("BaseUrl").Value;
            _httpClient = _testHostFixture.Client;
        }

        [Theory]
        [ClassData(typeof(CreateValidItem))]
        public async Task Unauthorized_Not_Logged_In(TestItem record) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, "", "", record);
        }

        [Theory]
        [ClassData(typeof(CreateValidItem))]
        public async Task Unauthorized_Invalid_Credentials(TestItem record) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, "user-does-not-exist", "not-a-valid-password", record);
        }

        [Theory]
        [ClassData(typeof(InactiveUsersCanNotLogin))]
        public async Task Unauthorized_Inactive_Users(Login login) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, login.Username, login.Password, null);
        }

        [Theory]
        [ClassData(typeof(CreateValidItem))]
        public async Task Simple_Users_Can_Not_Update(TestItem record) {
            await Forbidden.Action(_httpClient, _baseUrl, _url, _actionVerb, "simpleuser", Helpers.SimpleUserPassword(), record);
        }

        [Theory]
        [ClassData(typeof(UpdateInvalidItem))]
        public async Task Admins_Can_Not_Update_When_Invalid(TestItem record) {
            var actionResponse = await RecordInvalidNotSaved.Action(_httpClient, _baseUrl, _url, _actionVerb, "john", Helpers.AdminPassword(), record);
            Assert.Equal((HttpStatusCode)record.StatusCode, actionResponse.StatusCode);
        }

        [Theory]
        [ClassData(typeof(UpdateValidItem))]
        public async Task Admins_Can_Update_When_Valid(TestItem record) {
            await RecordSaved.Action(_httpClient, _baseUrl, _url, _actionVerb, "john", Helpers.AdminPassword(), record);
        }

    }

}