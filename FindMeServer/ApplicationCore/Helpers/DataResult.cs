namespace ApplicationCore.Helpers
{
    public class DataResult
    {
        public DataResult(object data, string message)
        {
            this.Data = data;
            this.Message = message;
        }

        public object Data { get; set; }
        public string Message { get; set; }
    }
}