using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using PhotoAlbum;

namespace ServiceCallerTests
{
    [TestClass]
    public class PhotoAlbumTests
    {
        private List<Photo> Photos;
        private ServiceCaller ServiceCaller;

        [TestInitialize]
        public void TestInitialize()
        {
            Photos = MockPhotos();
            ServiceCaller = new ServiceCaller();
        }

        private List<Photo> MockPhotos()
        {
            var photos = new List<Photo>();

            var testPhoto1 = new Photo()
            {
                AlbumId = 1,
                Id = 1,
                ThumbnailUrl = "thumbnail1",
                Title = "title1",
                Url = "url1"
            };

            var testPhoto2 = new Photo()
            {
                AlbumId = 1,
                Id = 2,
                ThumbnailUrl = "thumbnail2",
                Title = "title2",
                Url = "url2"
            };

            var testPhoto3 = new Photo()
            {
                AlbumId = 2,
                Id = 3,
                ThumbnailUrl = "thumbnail3",
                Title = "title3",
                Url = "url3"
            };

            photos.Add(testPhoto1);
            photos.Add(testPhoto2);
            photos.Add(testPhoto3);

            return photos;
        }
    }
}
