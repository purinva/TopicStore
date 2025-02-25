namespace Shared.Exceptions
{
    public class ConflictException : CustomException
    {
        public ConflictException(string message) 
            : base(message, 409)
        {
        }
    }
}