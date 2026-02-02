using System.Xml.Linq;

namespace XSitemaps;



/// <summary>
/// Provides conversion functionality to sitemap XML.
/// </summary>
internal interface ISitemapSerializable
{
    /// <summary>
    /// Converts to <see cref="XElement"/>.
    /// </summary>
    /// <returns></returns>
    XElement ToXElement();
}
