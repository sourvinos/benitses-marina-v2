namespace API.Infrastructure.Helpers {

    public enum Icons {
        Success,
        Info,
        Warning,
        Error
    }

    public static class ApiMessages {

        #region Generic messages

        public static string OK() { return "OK"; }
        public static string RecordInUse() { return "Record is used and can't be deleted"; }
        public static string AuthenticationFailed() { return "Authentication failed"; }
        public static string NotOwnRecord() { return "Only the owner of the account can make changes"; }
        public static string InvalidAccountFields() { return "One or more fields are invalid"; }
        public static string RecordNotFound() { return "Record not found"; }
        public static string UnknownError() { return "Something bad has happened"; }
        public static string NotUniqueUsernameOrEmail() { return "The username or the email are not unique"; }
        public static string ConcurrencyError() { return "Another user has already updated this record"; }

        #endregion

        #region Specific messages

        public static string InvalidBoatUsage() { return "The boat usage does not exist or is inactive"; }
        public static string InvalidHullType() { return "The hull type does not exist or is inactive"; }

        #endregion

    }

}