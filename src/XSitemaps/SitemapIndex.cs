using System.Collections.Generic;
using System.Xml.Linq;



namespace XSitemaps
{
    /// <summary>
    /// Represents information about all of the Sitemaps.
    /// </summary>
    public sealed class SitemapIndex : SitemapBase
    {
        #region Properties
        /// <summary>
        /// Gets information about an individual Sitemap.
        /// </summary>
        public IEnumerable<SitemapInfo> Sitemaps { get; }
        #endregion


        #region Constructors
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="sitemaps"></param>
        public SitemapIndex(IEnumerable<SitemapInfo> sitemaps)
            => this.Sitemaps = sitemaps;
        #endregion


        #region Overrides
        /// <summary>
        /// Converts to <see cref="XElement"/>.
        /// </summary>
        /// <returns></returns>
        private protected override XElement ToXElement()
        {
            //--- Create root element
            XNamespace ns = SitemapConstants.XmlNamespace;
            var root = new XElement(ns + "sitemapindex");

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
}
