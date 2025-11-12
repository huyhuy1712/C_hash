public abstract class ApiServiceBase
{
    protected readonly HttpClient _http;

    public ApiServiceBase()
    {
        _http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5198") // Dùng HTTP thay vì HTTPS
        };
    }
}
