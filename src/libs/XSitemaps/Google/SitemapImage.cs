namespace XSitemaps.Google;



/// <summary>
/// Encapsulates information about an image sitemap.
/// </summary>
/// <param name="location">URL of the image.</param>
/// <remarks>
/// Image sitemaps are a way of telling Google about other images on your site, especially those that we might not otherwise find (such as images your site reaches with JavaScript code).
/// You can create a separate image sitemap or add image sitemap tags to your existing sitemap; either approach is equally fine for Google.<br/>
/// <br/>
/// <a href="https://developers.google.com/search/docs/crawling-indexing/sitemaps/image-sitemaps"></a>
/// </remarks>
public readonly struct SitemapImage(string location)
{
    #region Properties
    /// <summary>
    /// Gets identifies the location of the URL of the image.
    /// </summary>
    public string Location { get; } = location;
    #endregion
}
