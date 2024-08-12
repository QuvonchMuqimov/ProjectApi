namespace Service.Exceptions
{
    public class UniversalException : Exception
    {
        int statusCode;
        public UniversalException(int code, string message) : base(message) 
        { 
            this.statusCode = code;
        }
    }
}
