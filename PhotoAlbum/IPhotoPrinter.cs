namespace PhotoAlbum
{
    public interface IPhotoPrinter
    {
        IServiceCaller ServiceCaller { get; set; }
        string GetAlbumOutput(string inputAlbumId);
    }
}
