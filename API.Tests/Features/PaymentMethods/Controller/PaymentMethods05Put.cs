using System.Net.Http;
using System.Threading.Tasks;
using Cases;
using Infrastructure;
using Responses;
using Xunit;

namespace PaymentMethods {

    [Collection("Sequence")]
    public class PaymentMethods05Put : IClassFixture<AppSettingsFixture> {

        #region variables

        private readonly AppSettingsFixture _appSettingsFixture;
        private readonly HttpClient _httpClient;
        private readonly TestHostFixture _testHostFixture = new();
        private readonly string _actionVerb = "put";
        private readonly string _baseUrl;
        private readonly string _url = "/paymentMethods";
        private readonly string _notFoundUrl = "/paymentMethods/9999";

        #endregion

        public PaymentMethods05Put(AppSettingsFixture appsettings) {
            _appSettingsFixture = appsettings;
            _baseUrl = _appSettingsFixture.Configuration.GetSection("TestingEnvironment").GetSection("BaseUrl").Value;
            _httpClient = _testHostFixture.Client;
        }

        [Theory]
        [ClassData(typeof(UpdateValidPaymentMethod))]
        public async Task Unauthorized_Not_Logged_In(TestPaymentMethod record) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, "", "", record);
        }

        [Theory]
        [ClassData(typeof(UpdateValidPaymentMethod))]
        public async Task Unauthorized_Invalid_Credentials(TestPaymentMethod record) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, "user-does-not-exist", "not-a-valid-password", record);
        }

        [Theory]
        [ClassData(typeof(InactiveUsersCanNotLogin))]
        public async Task Unauthorized_Inactive_Users(Login login) {
            await InvalidCredentials.Action(_httpClient, _baseUrl, _url, _actionVerb, login.Username, login.Password, null);
        }

        [Theory]
        [ClassData(typeof(UpdateValidPaymentMethod))]
        public async Task Simple_Users_Can_Not_Update(TestPaymentMethod record) {
            await Forbidden.Action(_httpClient, _baseUrl, _url, _actionVerb, "simpleuser", Helpers.SimpleUserPassword(), record);
        }

        [Fact]
        public async Task Admins_Can_Not_Update_When_Not_Found() {
            await RecordNotFound.Action(_httpClient, _baseUrl, _notFoundUrl, "john", Helpers.AdminPassword());
        }

        [Theory]
        [ClassData(typeof(UpdateValidPaymentMethod))]
        public async Task Admins_Can_Update_When_Valid(TestPaymentMethod record) {
            await RecordSaved.Action(_httpClient, _baseUrl, _url, _actionVerb, "john", Helpers.AdminPassword(), record);
        }

    }

}