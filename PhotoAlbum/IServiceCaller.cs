using System.Collections.Generic;

namespace PhotoAlbum
{
    public interface IServiceCaller
    {
        List<Photo> GetPhotos(string albumId = null);
    }
}
