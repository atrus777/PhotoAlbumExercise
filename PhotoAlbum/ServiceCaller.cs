using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.IO;

namespace PhotoAlbum
{
    /// <summary>
    /// Calls web service to obtain photos for a photo printer.
    /// </summary>
    public class ServiceCaller : IServiceCaller
    {
        #region Public Methods

        /// <summary>
        /// Get list of photos to print as an album, via a web service.
        /// </summary>
        /// <param name="albumId">Id number of the album to be obtained.</param>
        /// <returns></returns>
        public List<Photo> GetPhotos(string albumId = null)
        {
            var response = SendRequestToService(albumId);
            return ConvertResponseToPhotos(response);
        }

        #endregion

        #region Private Methods

        private HttpWebRequest CreateRequest(string albumId = null)
        {
            var serviceBaseUrl = ConfigurationManager.AppSettings["WebServiceUrl"];
            if (albumId != null)
                serviceBaseUrl += $"?albumId={albumId}";
            var httpRequest = WebRequest.Create(serviceBaseUrl) as HttpWebRequest;
            httpRequest.Method = "GET";
            httpRequest.ContentType = "application/json";
            return httpRequest;
        }

        private List<Photo> ConvertResponseToPhotos(HttpWebResponse response)
        {
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var serializedResponse = streamReader.ReadToEnd();
            var deserializedResponse = JsonConvert.DeserializeObject<List<Photo>>(serializedResponse);
            return deserializedResponse;
        }

        private HttpWebResponse SendRequestToService(string albumId = null)
        {
            var request = CreateRequest(albumId);
            var response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"The request failed with HTTP response code {response.StatusCode} and description {response.StatusDescription}");
            return response;
        }

        #endregion
    }
}
