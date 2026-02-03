namespace XSitemaps;



/// <summary>
/// Represents options for <see cref="SitemapSerializer"/>.
/// </summary>
public readonly struct SitemapSerializerOptions
{
    /// <summary>
    /// Gets or sets whether to enable indentation.
    /// </summary>
    public bool EnableIndent { get; init; }


    /// <summary>
    /// Gets or sets whether to enable gzip compression.
    /// </summary>
    public bool EnableGzipCompression { get; init; }
}
