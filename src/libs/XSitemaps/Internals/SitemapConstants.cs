namespace XSitemaps.Internals;



/// <summary>
/// Provides well known constants for sitemap.xml.
/// </summary>
internal static class SitemapConstants
{
    /// <summary>
    /// Represents maximum url count.
    /// </summary>
    public const int MaxUrlCount = 50000;



    /// <summary>
    /// Provides constants for Google-specific extensions.
    /// </summary>
    public static class GoogleExtensions
    {
        /// <summary>
        /// Represents maximum image count.
        /// </summary>
        public const int MaxImageCount = 1000;
    }
}
