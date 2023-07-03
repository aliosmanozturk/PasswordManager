namespace PasswordManager.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Result(bool success,string message)
        {
            this.Success = success;
            this.Message = message;
        }
        public Result(bool success)
        {
            this.Success = success;
        }
    }
}
