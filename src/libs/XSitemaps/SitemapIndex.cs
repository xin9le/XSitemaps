using System.Collections.Generic;
using System.Xml.Linq;
using XSitemaps.Internals;

namespace XSitemaps;



/// <summary>
/// Represents information about all of the Sitemaps.
/// </summary>
/// <param name="sitemaps"></param>
public sealed class SitemapIndex(IEnumerable<SitemapInfo> sitemaps) : ISitemapSerializable
{
    #region Properties
    /// <summary>
    /// Gets information about an individual Sitemap.
    /// </summary>
    public IEnumerable<SitemapInfo> Sitemaps { get; } = sitemaps;
    #endregion


    #region ISitemapSerializable
    /// <inheritdoc/>
    XElement ISitemapSerializable.ToXElement()
    {
        //--- Create root element
        var ns = SitemapNamespaces.Root;
        var xsi = SitemapNamespaces.XmlSchemaInstance;
        var schemaLocation = SitemapNamespaces.SiteindexSchemaLocation;
        var root = new XElement(
            ns + "sitemapindex",
            new XAttribute(XNamespace.Xmlns + nameof(xsi), xsi),
            new XAttribute(xsi + nameof(schemaLocation), schemaLocation));

        //--- Create and Add child elements.
        foreach (var x in this.Sitemaps)
        {
            var element = new XElement(ns + "sitemap");
            element.Add(new XElement(ns + "loc", x.Location));
            if (x.LastModifiedAt.HasValue)
            {
                var at = x.LastModifiedAt.Value.ToString("o");
                element.Add(new XElement(ns + "lastmod", at));
            }
            root.Add(element);
        }
        return root;
    }
    #endregion
}
