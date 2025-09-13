using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Cases;
using Infrastructure;
using Responses;
using Xunit;

namespace Reservations {

    [Collection("Sequence")]
    public class Reservations04Put : IClassFixture<AppSettingsFixture> {

        #region variables

        private readonly AppSettingsFixture _appSettingsFixture;
        private readonly HttpClient _httpClient;
        private readonly TestHostFixture _testHostFixture = new();
        private readonly string _actionVerb = "put";
        private readonly string _baseUrl;
        private readonly string _url = "/reservations";

        #endregion

        public Reservations04Put(AppSettingsFixture appsettings) {
            _appSettingsFixture = appsettings;
            _baseUrl = _appSettingsFixture.Configuration.GetSection("TestingEnvironment").GetSection("BaseUrl").Value;
            _httpClient = _testHostFixture.Client;
        }

        [Theory]
        [ClassData(typeof(UpdateValidReservation))]
        public async Task Unauthorized_Not_Logged_In(TestReservation record) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, "", "", record);
        }

        [Theory]
        [ClassData(typeof(UpdateValidReservation))]
        public async Task Unauthorized_Invalid_Credentials(TestReservation record) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, "user-does-not-exist", "not-a-valid-password", record);
        }

        [Theory]
        [ClassData(typeof(InactiveUsersCanNotLogin))]
        public async Task Unauthorized_Inactive_Users(Login login) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, login.Username, login.Password, null);
        }

        [Theory]
        [ClassData(typeof(UpdateValidReservation))]
        public async Task Simple_Users_Can_Not_Create(TestReservation record) {
            await Forbidden.Action(_httpClient, _baseUrl, _url, _actionVerb, "simpleuser", Helpers.SimpleUserPassword(), record);
        }

        [Theory]
        [ClassData(typeof(UpdateInvalidReservation))]
        public async Task Admins_Can_Not_Update_When_Invalid(TestReservation record) {
            var actionResponse = await RecordInvalidNotSaved.Action(_httpClient, _baseUrl, _url, _actionVerb, "john", Helpers.AdminPassword(), record);
            Assert.Equal((HttpStatusCode)record.StatusCode, actionResponse.StatusCode);
        }

        [Theory]
        [ClassData(typeof(UpdateValidReservation))]
        public async Task Admins_Can_Update_When_Valid(TestReservation record) {
            await RecordSaved.Action(_httpClient, _baseUrl, _url, _actionVerb, "john", Helpers.AdminPassword(), record);
        }

    }

}
