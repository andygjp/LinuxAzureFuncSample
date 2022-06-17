using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();

partial class Program
{
    [Function("Hello")]
    public static async Task<HttpResponseData> Hello(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET")] HttpRequestData request)
    {
        var response = request.CreateResponse();
        await response.WriteStringAsync("Hello world.");
        return response;
    }
}