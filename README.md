# XSitemaps

SEO (= Search Engine Optimization) is very important to improve the page views of your website. Sitemaps are defined in a simple XML-formatted file that can be read by search engines to more accurately crawl your site. And also Sitemaps are widely supported by many companies, including Google, Yahoo!, and Microsoft. See [sitemaps.org](https://www.sitemaps.org/) for more details.

This library provides a simple and easy to use `sitemap.xml` serializer.



# Supported features

- Sitemap file serialization
- SitemapIndex file serialization
- Split files according to the number of URLs
- Controllable indent
- GZIP compression



# Support platform

- .NET Standard 1.1+



# Create `Sitemap.xml`

```cs
//--- Create Sitemaps
var modifiedAt = DateTimeOffset.Now;
var urls = new[]
{
    new SitemapUrl("https://blog.xin9le.net", modifiedAt, ChangeFrequency.Daily, priority: 1.0),
    new SitemapUrl("https://blog.xin9le.net/entry/rx-intro"),
    new SitemapUrl("https://blog.xin9le.net/entry/async-method-intro", frequency: ChangeFrequency.Weekly),
};
var sitemaps = Sitemap.Create(urls, maxUrlCount: 2);

//--- Output to files
for (var i = 0; i < sitemaps.Length; i++)
{
    var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    var path = Path.Combine(desktop, $"Sitemap_{i}.xml");
    using (var stream = new FileStream(path, FileMode.CreateNew))
    {
        var options = new SerializeOptions
        {
            EnableIndent = true,
            EnableGzipCompression = false,
        };
        sitemaps[i].Serialize(stream, options);
    }
}

//--- Sitemap_0.xml
/*
<?xml version="1.0" encoding="utf-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <url>
    <loc>https://blog.xin9le.net</loc>
    <lastmod>2020-01-12T00:07:12.2351485+09:00</lastmod>
    <changefreq>daily</changefreq>
    <priority>1</priority>
  </url>
  <url>
    <loc>https://blog.xin9le.net/entry/rx-intro</loc>
    <changefreq>never</changefreq>
    <priority>0.5</priority>
  </url>
</urlset>
*/

//--- Sitemap_1.xml
/*
<?xml version="1.0" encoding="utf-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <url>
    <loc>https://blog.xin9le.net/entry/async-method-intro</loc>
    <changefreq>weekly</changefreq>
    <priority>0.5</priority>
  </url>
</urlset>
*/
```


# Create `SitemapIndex.xml`

```cs
//--- Create SitemapIndex
var modifiedAt = DateTimeOffset.Now;
var info = new[]
{
    new SitemapInfo("https://example.com/Sitemap_0.xml", modifiedAt),
    new SitemapInfo("https://example.com/Sitemap_1.xml"),
};
var index = new SitemapIndex(info);

//--- Output to file
var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var path = Path.Combine(desktop, $"SitemapIndex.xml");
using (var stream = new FileStream(path, FileMode.CreateNew))
{
    var options = new SerializeOptions
    {
        EnableIndent = true,
        EnableGzipCompression = false,
    };
    index.Serialize(stream, options);
}

/*
<?xml version="1.0" encoding="utf-8"?>
<sitemapindex xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <sitemap>
    <loc>https://example.com/Sitemap_0.xml</loc>
    <lastmod>2020-01-12T00:13:24.4802279+09:00</lastmod>
  </sitemap>
  <sitemap>
    <loc>https://example.com/Sitemap_1.xml</loc>
  </sitemap>
</sitemapindex>
*/
```


# Installation

Getting started from downloading [NuGet](https://www.nuget.org/packages/XSitemaps) package.

```
PM> Install-Package XSitemaps
```



# License

This library is provided under [MIT License](http://opensource.org/licenses/MIT).



# Author

Takaaki Suzuki (a.k.a [@xin9le](https://twitter.com/xin9le)) is software developer in Japan who awarded Microsoft MVP for Developer Technologies (C#) since July 2012.