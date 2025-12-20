using System;
using System.Xml.Linq;



namespace XSitemaps
{
    /// <summary>
    /// Represents indivisual sitemap.xml file.
    /// </summary>
    public sealed class Sitemap : SitemapBase
    {
        #region Properties
        /// <summary>
        /// Gets URLs.
        /// </summary>
        public ReadOnlyMemory<SitemapUrl> Urls { get; }
        #endregion


        #region Constructors
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="urls"></param>
        private Sitemap(ReadOnlyMemory<SitemapUrl> urls)
            => this.Urls = urls;
        #endregion


        #region Create
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="maxUrlCount"></param>
        /// <returns></returns>
        public static Sitemap[] Create(ReadOnlyMemory<SitemapUrl> urls, int maxUrlCount = SitemapConstants.MaxUrlCount)
        {
            var count = calculateSeparationCount(urls.Length, maxUrlCount);
            var buffer = new Sitemap[count];
            for (var i = 0; i < buffer.Length; i++)
            {
                var start = i * maxUrlCount;
                var length = (start + maxUrlCount < urls.Length) ? maxUrlCount : urls.Length - start;
                var slice = urls.Slice(start, length);
                buffer[i] = new Sitemap(slice);
            }
            return buffer;

            #region Local Functions
            static int calculateSeparationCount(int urlCount, int maxCount)
            {
                var div = urlCount / maxCount;
                var mod = urlCount % maxCount;
                return (mod == 0) ? div : div + 1;
            }
            #endregion
        }
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
            XNamespace xsi = SitemapConstants.XmlSchemaInstance;
            XNamespace schemaLocation = SitemapConstants.SitemapSchemaLocation;
            var root = new XElement(
                ns + "urlset",
                new XAttribute(XNamespace.Xmlns + nameof(xsi), xsi),
                new XAttribute(xsi + nameof(schemaLocation), schemaLocation));

            //--- Create and Add child elements.
            var urls = this.Urls.Span;
            for (var i = 0; i < urls.Length; i++)
            {
                //--- Create URL element
                var url = urls[i];
                var element = new XElement(ns + "url");
                element.Add(new XElement(ns + "loc", url.Location));
                if (url.LastModifiedAt.HasValue)
                {
                    var at = url.LastModifiedAt.Value.ToString("o");
                    element.Add(new XElement(ns + "lastmod", at));
                }
                if (url.ChangeFrequency.HasValue)
                {
                    element.Add(new XElement(ns + "changefreq", url.ChangeFrequency.Value.ToParameter()));
                }
                if (url.Priority.HasValue)
                {
                    element.Add(new XElement(ns + "priority", url.Priority.Value));
                }
                root.Add(element);
            }
            return root;
        }
        #endregion
    }
}
