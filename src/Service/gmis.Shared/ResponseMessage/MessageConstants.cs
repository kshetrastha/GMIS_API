namespace gmis.Shared.ResponseMessage
{
    public static class MessageConstants
    {
        public static string Deleted = $"Deleted Successfully.";
        public static string Fetched = $"Fetched successfully.";
        public static string Error = $"Internal server error.";
        public static string FileUploadSuccess = $"File uploaded successfully.";
        public static string UserInvalidError = $"Invalid username or password.";

        public static string CreatedSuccess(string message) => $"{message} created successfully.";

        public static string UpdatedSuccess(string message) => $"{message} updated successfully.";
        public static string NotFoundExceptionMessage(string tableName) => $"{tableName} not found.";

    }
}
