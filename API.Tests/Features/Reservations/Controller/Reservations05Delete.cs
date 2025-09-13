using System.Net.Http;
using System.Threading.Tasks;
using Cases;
using Infrastructure;
using Responses;
using Xunit;

namespace Reservations {

    [Collection("Sequence")]
    public class Reservations05Delete : IClassFixture<AppSettingsFixture> {

        #region variables

        private readonly AppSettingsFixture _appSettingsFixture;
        private readonly HttpClient _httpClient;
        private readonly TestHostFixture _testHostFixture = new();
        private readonly string _actionVerb = "delete";
        private readonly string _baseUrl;
        private readonly string _notFoundUrl = "/reservations/b140036a-5b03-4098-9774-8878f252fdb7";
        private readonly string _deleteUrl = "/reservations/91430e54-c26b-44aa-956b-ed4477c4013a";

        #endregion

        public Reservations05Delete(AppSettingsFixture appsettings) {
            _appSettingsFixture = appsettings;
            _baseUrl = _appSettingsFixture.Configuration.GetSection("TestingEnvironment").GetSection("BaseUrl").Value;
            _httpClient = _testHostFixture.Client;
        }

        [Fact]
        public async Task Unauthorized_Not_Logged_In() {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _deleteUrl, _actionVerb, "", "", null);
        }

        [Fact]
        public async Task Unauthorized_Invalid_Credentials() {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _deleteUrl, _actionVerb, "user-does-not-exist", "not-a-valid-password", null);
        }

        [Theory]
        [ClassData(typeof(InactiveUsersCanNotLogin))]
        public async Task Unauthorized_Inactive_Users(Login login) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _deleteUrl, _actionVerb, login.Username, login.Password, null);
        }

        [Fact]
        public async Task Admins_Not_Found_When_Not_Exists() {
            await RecordNotFound.Action(_httpClient, _baseUrl, _notFoundUrl, "john", Helpers.AdminPassword());
        }

        [Fact]
        public async Task Simple_Users_Can_Not_Delete() {
            await Forbidden.Action(_httpClient, _baseUrl, _deleteUrl, _actionVerb, "simpleuser", Helpers.SimpleUserPassword(), null);
        }

        [Fact]
        public async Task Admins_Can_Delete() {
            await RecordDeleted.Action(_httpClient, _baseUrl, _deleteUrl, "john", Helpers.AdminPassword());
        }

    }

}