using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Vtex.Api.Context;

namespace DotNetService.Clients
{
    // A helper class to configure a HttpClient according to VTEX Core Commerce api specs.
    public static class VtexHttpClient
    {
        private const string AuthorizationHeader = "VtexIdclientAutCookie";
        private const string UseHttpsHeader = "X-Vtex-Use-Https";

        public static void Configure(IServiceProvider serviceProvider, HttpClient client)
        {
            // The service context provides meta information about the app and its environment 
            var serviceContext = serviceProvider.GetService<IIOServiceContext>();
            
            // So we use it to configure the base url for our core commerce api client
            var env = serviceContext.Vtex.JanusEnv == "beta" ? "beta" : "stable";
            var baseUri = $"https://{serviceContext.Vtex.Account}.vtexcommerce{env}.com.br";
                
            if (!Uri.TryCreate($"{baseUri}", UriKind.Absolute, out var uri))
                throw new Exception($"Invalid Vtex baseUri: {baseUri}");
            
            client.BaseAddress = uri;
            
            // Here we ensure we are relaying the correct header parameters for the app to work
            client.DefaultRequestHeaders.Add(AuthorizationHeader, serviceContext.Vtex.AuthToken);
            client.DefaultRequestHeaders.Add(UseHttpsHeader, "true");
        }
    }
}