namespace EventBor.Backend.API.Helpers;

public class Response
{
    public int StatusCode { get; set; } = 200;
    public string Message { get; set; }
    public object Data { get; set; }
}
