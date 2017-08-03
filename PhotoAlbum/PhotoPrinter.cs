using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum
{
    /// <summary>
    /// PhotoPrinter takes an IServiceCaller to request photos from a webservice, and prints out the photos.
    /// </summary>
    public class PhotoPrinter : IPhotoPrinter
    {
        #region Properties

        public IServiceCaller ServiceCaller { get; set; }

        #endregion

        #region Constructors

        public PhotoPrinter(IServiceCaller serviceCaller)
        {
            ServiceCaller = serviceCaller;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the output string for the album to be printed.
        /// </summary>
        /// <param name="inputAlbumId">Id of the album to be printed.</param>
        /// <returns></returns>
        public string GetAlbumOutput(string inputAlbumId)
        {
            var filteredAlbum = new List<Photo>();
            filteredAlbum = ServiceCaller.GetPhotos(inputAlbumId);
            return CreateAlbumOutput(filteredAlbum);
        }

        #endregion

        #region Private Methods

        private static string CreateAlbumOutput(List<Photo> photos)
        {
            var stringBuilder = new StringBuilder();
            foreach (var picture in photos)
                stringBuilder.Append($"[{picture.Id.ToString()}] {picture.Title}\n");
            return stringBuilder.ToString();
        }

        #endregion
    }
}
