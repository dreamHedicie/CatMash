using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CathMash.Tests
{
    public class HttpMessageHandlerMock : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, CancellationToken, HttpResponseMessage> _send;

        public HttpMessageHandlerMock(Func<HttpRequestMessage, CancellationToken, HttpResponseMessage> send)
        {
            _send = send;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_send(request, cancellationToken));
        }
    }
}
