namespace PasswordManager.Models
{
    public class DataResult<T>:Result
    {
        public T Data { get; set; }

        public DataResult(T data,bool success,string message) : base(success, message)
        {
            this.Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            this.Data = data;
        }
    }
}
