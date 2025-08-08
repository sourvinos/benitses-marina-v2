namespace API.Infrastructure.Responses {

    public class ErrorResponse : IResponse {

        public int Code { get; set; }
        public string Icon { get; set; }
        public string Message { get; set; }

    }

}