using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherMonitoring.Infrastructure.HttpClients
{
    public interface IHttpClientWrapper
    {
        Task<TSuccessResponse> SendAsync<TSuccessResponse>(HttpRequestMessage message);
    }
}