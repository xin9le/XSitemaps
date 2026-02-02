using System.IO;
using System.IO.Compression;
#if !NETSTANDARD2_0
using System.Threading;
using System.Threading.Tasks;
#endif
using System.Xml.Linq;

namespace XSitemaps;



/// <summary>
/// Provides functionality to serialize <see cref="Sitemap"/> and <see cref="SitemapIndex"/> to XML.
/// </summary>
public static class SitemapSerializer
{
    /// <summary>
    /// Serialize <see cref="Sitemap"/> synchronously.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="sitemap"></param>
    /// <param name="options"></param>
    public static void Serialize(Stream stream, Sitemap sitemap, in SerializeOptions options = default)
        => SerializeCore(stream, sitemap, options);


    /// <summary>
    /// Serialize <see cref="SitemapIndex"/> synchronously.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="index"></param>
    /// <param name="options"></param>
    public static void Serialize(Stream stream, SitemapIndex index, in SerializeOptions options = default)
        => SerializeCore(stream, index, options);


#if !NETSTANDARD2_0
    /// <summary>
    /// Serialize <see cref="Sitemap"/> asynchronously.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="sitemap"></param>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    public static async Task SerializeAsync(Stream stream, Sitemap sitemap, SerializeOptions options = default, CancellationToken cancellationToken = default)
        => await SerializeAsyncCore(stream, sitemap, options, cancellationToken).ConfigureAwait(false);


    /// <summary>
    /// Serialize <see cref="SitemapIndex"/> asynchronously.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="index"></param>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    public static async Task SerializeAsync(Stream stream, SitemapIndex index, SerializeOptions options = default, CancellationToken cancellationToken = default)
        => await SerializeAsyncCore(stream, index, options, cancellationToken).ConfigureAwait(false);
#endif


    #region Helpers
    /// <summary>
    /// Serialize synchronously.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="stream"></param>
    /// <param name="instance"></param>
    /// <param name="options"></param>
    private static void SerializeCore<T>(Stream stream, T instance, in SerializeOptions options)
        where T : ISitemapSerializable
    {
        var xml = instance.ToXElement();
        var xmlSaveOption = options.EnableIndent ? SaveOptions.None : SaveOptions.DisableFormatting;
        if (options.EnableGzipCompression)
        {
            using (var gzip = new GZipStream(stream, CompressionLevel.Optimal))
                xml.Save(gzip, xmlSaveOption);
        }
        else
        {
            xml.Save(stream, xmlSaveOption);
        }
    }


#if !NETSTANDARD2_0
    /// <summary>
    /// Serialize asynchronously.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="stream"></param>
    /// <param name="instance"></param>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    private static async Task SerializeAsyncCore<T>(Stream stream, T instance, SerializeOptions options, CancellationToken cancellationToken)
        where T : ISitemapSerializable
    {
        var xml = instance.ToXElement();
        var xmlSaveOption = options.EnableIndent ? SaveOptions.None : SaveOptions.DisableFormatting;
        if (options.EnableGzipCompression)
        {
            using (var gzip = new GZipStream(stream, CompressionLevel.Optimal))
                await xml.SaveAsync(gzip, xmlSaveOption, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            await xml.SaveAsync(stream, xmlSaveOption, cancellationToken).ConfigureAwait(false);
        }
    }
#endif
    #endregion
}
