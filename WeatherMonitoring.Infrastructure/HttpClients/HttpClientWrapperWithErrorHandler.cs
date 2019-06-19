using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherMonitoring.Infrastructure.HttpClients
{
    public class HttpClientWrapperWithErrorHandler : IHttpClientWrapper
    {
        public IHttpClientWrapper HttpClientWrapper { get; }

        public HttpClientWrapperWithErrorHandler(
            IHttpClientWrapper httpClientWrapper)
        {
            HttpClientWrapper = httpClientWrapper ?? throw new ArgumentNullException(nameof(httpClientWrapper));
        }

        public Task<TSuccessResponse> SendAsync<TSuccessResponse>(HttpRequestMessage message)
        {
            try
            {
                return HttpClientWrapper.SendAsync<TSuccessResponse>(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
