using System.Collections.Generic;

namespace XSitemaps.Google;



/// <summary>
/// Encapsulates Google-specific extensions for sitemap.xml.
/// </summary>
/// <param name="images">A collection of images related to the page.</param>
public sealed class GoogleExtensions(IEnumerable<SitemapImage>? images = null)
{
    /// <summary>
    /// Gets a collection of images related to the page.
    /// </summary>
    public IEnumerable<SitemapImage>? Images { get; } = images;
}
