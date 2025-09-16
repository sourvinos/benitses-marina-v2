using System.Net.Http;
using System.Threading.Tasks;
using Cases;
using Infrastructure;
using Responses;
using Xunit;

namespace Reservations {

    [Collection("Sequence")]
    public class Reservations02GetById : IClassFixture<AppSettingsFixture> {

        #region variables

        private readonly AppSettingsFixture _appSettingsFixture;
        private readonly HttpClient _httpClient;
        private readonly TestHostFixture _testHostFixture = new();
        private readonly string _actionVerb = "get";
        private readonly string _url = "/reservations/08ddf478-3633-41ce-8dd9-d7abb2f9be3c";
        private readonly string _baseUrl;
        private readonly string _notFoundUrl = "/reservations/b140036a-5b03-4098-9774-8878f252fdb7";

        #endregion

        public Reservations02GetById(AppSettingsFixture appsettings) {
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

        [Theory]
        [ClassData(typeof(ActiveUsersCanLogin))]
        public async Task Active_Users_Not_Found_When_Not_Exists(Login login) {
            await RecordNotFound.Action(_httpClient, _baseUrl, _notFoundUrl, login.Username, login.Password);
        }

        [Theory]
        [ClassData(typeof(ActiveUsersCanLogin))]
        public async Task Active_Users_Can_Get_By_Id(Login login) {
            await RecordFound.Action(_httpClient, _baseUrl, _url, login.Username, login.Password);
        }

    }

}