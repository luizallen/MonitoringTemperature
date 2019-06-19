using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherMonitoring.Infrastructure.Serializers;

namespace WeatherMonitoring.Infrastructure.HttpClients
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public HttpClient HttpClient { get; }

        public ICustomSerialization CustomSerialization { get; }

        public HttpClientWrapper(
            HttpClient httpClient,
            ICustomSerialization customSerialization)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            CustomSerialization = customSerialization ?? throw new ArgumentNullException(nameof(customSerialization));
        }

        public async Task<TSuccessResponse> SendAsync<TSuccessResponse>(HttpRequestMessage message)
        {
            var response = await HttpClient.SendAsync(message);

            if (response.StatusCode != HttpStatusCode.OK)
                throw null;

            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = (TSuccessResponse)CustomSerialization.Deserialize(stringResponse, typeof(TSuccessResponse));

            return result;
        }
    }
}
