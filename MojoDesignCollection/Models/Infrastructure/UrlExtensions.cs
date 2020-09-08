using Microsoft.AspNetCore.Http;

namespace MojoDesignCollection.Models.Infrastructure
{
    public static class UrlExtensions
    {
        /// <summary>
        /// Generates a URL that browser will be returned after the card has been updated
        /// </summary>
        /// <param name="httpRequest">http request</param>
        /// <returns>updated url </returns>
        public static string PathAndQuery(this HttpRequest httpRequest)
            => httpRequest.QueryString.HasValue ?
                $"{httpRequest.Path}{httpRequest.QueryString}" : httpRequest.Path.ToString();
    }
}
