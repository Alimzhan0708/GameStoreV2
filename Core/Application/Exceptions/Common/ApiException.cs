namespace Application.Exceptions.Common
{
    public class ApiException : Exception
    {
        public ApiException(string errorMessage): base(errorMessage) 
        {
        }
    }
}
