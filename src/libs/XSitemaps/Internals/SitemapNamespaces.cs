using System.Xml.Linq;

namespace XSitemaps.Internals;



/// <summary>
/// Provides sitemap.xml namespaces.
/// </summary>
internal static class SitemapNamespaces
{
    /// <summary>
    /// Represents root namespace for sitemap.xml.
    /// </summary>
    public static readonly XNamespace Root = "http://www.sitemaps.org/schemas/sitemap/0.9";


    /// <summary>
    /// Represents schema instance namespace for sitemap.xml.
    /// </summary>
    public static readonly XNamespace XmlSchemaInstance = "http://www.w3.org/2001/XMLSchema-instance";


    /// <summary>
    /// Represents schema location namespace for sitemap.xml.
    /// </summary>
    public static readonly XNamespace SitemapSchemaLocation = "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd";


    /// <summary>
    /// Represents schema location namespace for sitemapindex.xml.
    /// </summary>
    public static readonly XNamespace SiteindexSchemaLocation = "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/siteindex.xsd";
}
