namespace CatGiphyApi.Models
{
    public class GiphyResponse
    {
        public GifData[] Data { get; set; } = Array.Empty<GifData>();
    }

    public class GifData
    {
        public GifImages Images { get; set; } = new GifImages();
    }

    public class GifImages
    {
        public GifOriginal Original { get; set; } = new GifOriginal();
    }

    public class GifOriginal
    {
        public string Url { get; set; } = string.Empty;
    }
}
