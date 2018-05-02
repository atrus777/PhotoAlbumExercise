using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using PhotoAlbum;

namespace PhotoAlbumUnitTests
{
    [TestClass]
    public class PhotoPrinterTests
    {
        private IServiceCaller _mockServiceCaller = A.Fake<IServiceCaller>();
        private PhotoPrinter _photoPrinter;

        [TestInitialize]
        public void InitializeTests()
        {
            _photoPrinter = new PhotoPrinter(_mockServiceCaller);
        }

        [TestMethod]
        public void GetAlbumOutput_ValidCall_CallsGetPhotos()
        {
            // Arrange
            A.CallTo(() => _mockServiceCaller.GetPhotos("1")).Returns(new List<Photo>());
            // Act
            _photoPrinter.GetAlbumOutput("1");
            // Assert
            A.CallTo(() => _mockServiceCaller.GetPhotos("1")).MustHaveHappened(Repeated.Exactly.Once);
        }

        [TestMethod]
        public void GetAlbumOutput_NoPhotosFound_EmptyStringReturned()
        {
            // Arrange
            A.CallTo(() => _mockServiceCaller.GetPhotos("1")).Returns(new List<Photo>());
            // Act
            var result = _photoPrinter.GetAlbumOutput("1");
            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void GetAlbumOutput_OnePhotoFound_PopulatedStringReturned()
        {
            // Arrange
            var photos = new List<Photo>();

            var testPhoto1 = new Photo()
            {
                AlbumId = 1,
                Id = 1,
                ThumbnailUrl = "thumbnail1",
                Title = "title1",
                Url = "url1"
            };

            photos.Add(testPhoto1);

            A.CallTo(() => _mockServiceCaller.GetPhotos("1")).Returns(photos);

            // Act
            var result = _photoPrinter.GetAlbumOutput("1");
            // Assert
            Assert.AreEqual("[1] title1\n", result);
        }

        [TestMethod]
        public void GetAlbumOutput_TwoPhotosFound_StringWithTwoLinesReturned()
        {
            // Arrange
            var photos = new List<Photo>();
            var testPhoto1 = new Photo() { Id = 1, Title = "title1" };
            var testPhoto2 = new Photo() { Id = 2, Title = "title2" };
            photos.Add(testPhoto1);
            photos.Add(testPhoto2);

            A.CallTo(() => _mockServiceCaller.GetPhotos("1")).Returns(photos);

            // Act
            var result = _photoPrinter.GetAlbumOutput("1");
            // Assert
            var lineCount = result.Split('\n').Length - 1;
            Assert.AreEqual(2, lineCount);
        }
    }
}
