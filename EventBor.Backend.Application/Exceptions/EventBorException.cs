namespace EventBor.Backend.Application.Exceptions;

public class EventBorException : Exception
{
    public int StatusCode {  get; set; }
    public EventBorException(int code, string message) : base(message)
    {
        StatusCode = code;
    }
}
