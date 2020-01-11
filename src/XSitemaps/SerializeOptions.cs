namespace XSitemaps
{
    /// <summary>
    /// Represents sitemap serialization options.
    /// </summary>
    public struct SerializeOptions
    {
        /// <summary>
        /// Gets or sets whether to enable indentation.
        /// </summary>
        public bool EnableIndent { get; set; }


        /// <summary>
        /// Gets or sets whether to enable gzip compression.
        /// </summary>
        public bool EnableGzipCompression { get; set; }
    }
}
