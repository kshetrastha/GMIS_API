namespace gmis.Application.Common.Model
{
    public class ResponseModel<T>
    {
        public ResponseModel() { }
        public ResponseModel(bool success,string message,T response)
        {
            Succeeded = success;
            Message = message;
            Errors = null;
            Data = response;
        }
        public ResponseModel(T response)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = response;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
