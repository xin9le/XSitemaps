namespace XSitemaps
{
    /// <summary>
    /// Provides well known constants for sitemap.xml.
    /// </summary>
    internal static class SitemapConstants
    {
        /// <summary>
        /// Represents maximum url count.
        /// This is constant value.
        /// </summary>
        public const int MaxUrlCount = 50000;


        /// <summary>
        /// Represents namespace for sitemap.xml.
        /// This is constant value.
        /// </summary>
        public const string XmlNamespace = "http://www.sitemaps.org/schemas/sitemap/0.9";


        /// <summary>
        /// Represents schema instance namespace for sitemap.xml.
        /// This is constant value.
        /// </summary>
        public const string XmlSchemaInstance = "http://www.w3.org/2001/XMLSchema-instance";


        /// <summary>
        /// Represents schema location namespace for sitemap.xml.
        /// This is constant value.
        /// </summary>
        public const string SitemapSchemaLocation = "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd";


        /// <summary>
        /// Represents schema location namespace for sitemapindex.xml.
        /// This is constant value.
        /// </summary>
        public const string SiteindexSchemaLocation = "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/siteindex.xsd";
    }
}
