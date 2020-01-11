using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace XSitemaps
{
    /// <summary>
    /// Provides base class of <see cref="Sitemap"/> and <see cref="SitemapIndex"/>.
    /// </summary>
    public abstract class SitemapBase
    {
        #region Serialize
        /// <summary>
        /// Serialize synchronously.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public byte[] Serialize(SerializeOptions options = default)
        {
            using (var stream = new MemoryStream())
            {
                this.Serialize(stream, options);
                return stream.ToArray();
            }
        }


        /// <summary>
        /// Serialize synchronously.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        public void Serialize(Stream stream, SerializeOptions options = default)
        {
            var xml = this.ToXElement();
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


#if NETSTANDARD2_1
        /// <summary>
        /// Serialize asynchronously.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<byte[]> SerializeAsync(SerializeOptions options = default, CancellationToken cancellationToken = default)
        {
            using (var stream = new MemoryStream())
            {
                await this.SerializeAsync(stream, options, cancellationToken).ConfigureAwait(false);
                return stream.ToArray();
            }
        }


        /// <summary>
        /// Serialize asynchronously.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task SerializeAsync(Stream stream, SerializeOptions options = default, CancellationToken cancellationToken = default)
        {
            var xml = this.ToXElement();
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


        #region Abstruact
        /// <summary>
        /// Converts to <see cref="XElement"/>.
        /// </summary>
        /// <returns></returns>
        private protected abstract XElement ToXElement();
        #endregion
    }
}
