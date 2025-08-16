using System.Net.Http;
using System.Threading.Tasks;
using Cases;
using Infrastructure;
using Responses;
using Xunit;

namespace BoatUsages {

    [Collection("Sequence")]
    public class BoatUsages04Post : IClassFixture<AppSettingsFixture> {

        #region variables

        private readonly AppSettingsFixture _appSettingsFixture;
        private readonly HttpClient _httpClient;
        private readonly TestHostFixture _testHostFixture = new();
        private readonly string _actionVerb = "post";
        private readonly string _baseUrl;
        private readonly string _url = "/boatUsages";

        #endregion

        public BoatUsages04Post(AppSettingsFixture appsettings) {
            _appSettingsFixture = appsettings;
            _baseUrl = _appSettingsFixture.Configuration.GetSection("TestingEnvironment").GetSection("BaseUrl").Value;
            _httpClient = _testHostFixture.Client;
        }

        [Theory]
        [ClassData(typeof(CreateValidBoatUsage))]
        public async Task Unauthorized_Not_Logged_In(TestBoatUsage record) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, "", "", record);
        }

        [Theory]
        [ClassData(typeof(CreateValidBoatUsage))]
        public async Task Unauthorized_Invalid_Credentials(TestBoatUsage record) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, "user-does-not-exist", "not-a-valid-password", record);
        }

        [Theory]
        [ClassData(typeof(InactiveUsersCanNotLogin))]
        public async Task Unauthorized_Inactive_Users(Login login) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, login.Username, login.Password, null);
        }

        [Theory]
        [ClassData(typeof(CreateValidBoatUsage))]
        public async Task Simple_Users_Can_Not_Create(TestBoatUsage record) {
            await Forbidden.Action(_httpClient, _baseUrl, _url, _actionVerb, "simpleuser", Helpers.SimpleUserPassword(), record);
        }

        [Theory]
        [ClassData(typeof(CreateValidBoatUsage))]
        public async Task Admins_Can_Create_When_Valid(TestBoatUsage record) {
            await RecordSaved.Action(_httpClient, _baseUrl, _url, _actionVerb, "john", Helpers.AdminPassword(), record);
        }

    }

}