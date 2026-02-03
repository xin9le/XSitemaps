# XSitemaps
SEO (= Search Engine Optimization) is very important to improve the page views of your website. Sitemaps are defined in a simple XML-formatted file that can be read by search engines to more accurately crawl your site. And also Sitemaps are widely supported by many companies, including Google, Yahoo!, and Microsoft. See [sitemaps.org](https://www.sitemaps.org/) for more details.

This library provides a simple and easy to use `sitemap.xml` serializer.

[![Releases](https://img.shields.io/github/release/xin9le/XSitemaps.svg)](https://github.com/xin9le/XSitemaps/releases)
[![Nuget packages](https://img.shields.io/nuget/v/XSitemaps.svg)](https://www.nuget.org/packages/XSitemaps/)
[![GitHub license](https://img.shields.io/github/license/xin9le/XSitemaps)](https://github.com/xin9le/XSitemaps/blob/main/LICENSE)



# Supported features
- Sitemap file serialization
    - Google-specific extensions (currently, image only)
- SitemapIndex file serialization
- Split files according to the number of URLs
- Controllable indent
- GZIP compression



# Support platform
- .NET Standard 2.0+
- .NET 8+



# How to use
## Create `Sitemap.xml`

```cs
//--- Create Sitemaps
var modifiedAt = new DateTimeOffset(2026, 1, 2, 12, 34, 56, TimeSpan.FromHours(9));
var urls
    = new SitemapUrl[]
    {
        new("https://blog.xin9le.net"),
        new("https://blog.xin9le.net/entry/rx-intro", modifiedAt, ChangeFrequency.Daily, priority: 0.8),
        new("https://blog.xin9le.net/entry/async-method-intro", frequency: ChangeFrequency.Weekly),
        new("https://example.com/sample1.html", google: new
        (
            images: [
                new("https://example.com/image.jpg"),
                new("https://example.com/photo.jpg"),
            ]
        )),
        new("https://example.com/sample2.html", google: new
        (
            images: [
                new("https://example.com/picture.jpg"),
            ]
        )),
    };
var sitemaps = Sitemap.Create(urls, maxUrlCount: 3);

//--- Output to files
foreach (var (index, sitemap) in sitemaps.Index())
{
    var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    var path = Path.Combine(desktop, $"sitemap{index}.xml");
    using (var stream = new FileStream(path, FileMode.CreateNew))
    {
        var options = new SerializeOptions
        {
            EnableIndent = true,
            EnableGzipCompression = false,
        };
        SitemapSerializer.Serialize(stream, sitemap, options);
    }
}
```
```xml
//--- sitemap0.xml
<?xml version="1.0" encoding="utf-8"?>
<urlset xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd" xmlns:image="http://www.google.com/schemas/sitemap-image/1.1" xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <url>
    <loc>https://blog.xin9le.net</loc>
  </url>
  <url>
    <loc>https://blog.xin9le.net/entry/rx-intro</loc>
    <lastmod>2026-01-02T12:34:56.0000000+09:00</lastmod>
    <changefreq>daily</changefreq>
    <priority>0.8</priority>
  </url>
  <url>
    <loc>https://blog.xin9le.net/entry/async-method-intro</loc>
    <changefreq>weekly</changefreq>
  </url>
</urlset>

//--- sitemap1.xml
<?xml version="1.0" encoding="utf-8"?>
<urlset xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd" xmlns:image="http://www.google.com/schemas/sitemap-image/1.1" xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <url>
    <loc>https://example.com/sample1.html</loc>
    <image:image>
      <image:loc>https://example.com/image.jpg</image:loc>
    </image:image>
    <image:image>
      <image:loc>https://example.com/photo.jpg</image:loc>
    </image:image>
  </url>
  <url>
    <loc>https://example.com/sample2.html</loc>
    <image:image>
      <image:loc>https://example.com/picture.jpg</image:loc>
    </image:image>
  </url>
</urlset>
```


## Create `SitemapIndex.xml`

```cs
//--- Create SitemapIndex
var modifiedAt = new DateTimeOffset(2026, 1, 2, 12, 34, 56, TimeSpan.FromHours(9));
var info = new SitemapInfo[]
{
    new("https://example.com/sitemap0.xml", modifiedAt),
    new("https://example.com/sitemap1.xml"),
};
var index = new SitemapIndex(info);

//--- Output to file
var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var path = Path.Combine(desktop, $"sitemapindex.xml");
using (var stream = new FileStream(path, FileMode.CreateNew))
{
    var options = new SerializeOptions
    {
        EnableIndent = true,
        EnableGzipCompression = false,
    };
    SitemapSerializer.Serialize(stream, index, options);
}
```
```xml
<?xml version="1.0" encoding="utf-8"?>
<sitemapindex xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/siteindex.xsd" xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <sitemap>
    <loc>https://example.com/sitemap0.xml</loc>
    <lastmod>2026-01-02T12:34:56.0000000+09:00</lastmod>
  </sitemap>
  <sitemap>
    <loc>https://example.com/sitemap1.xml</loc>
  </sitemap>
</sitemapindex>
```


## Installation
Getting started from downloading [NuGet](https://www.nuget.org/packages/XSitemaps) package.

```
dotnet add package XSitemaps
```



# License
This library is provided under [MIT License](http://opensource.org/licenses/MIT).



# Author
Takaaki Suzuki (a.k.a [@xin9le](https://x.com/xin9le)) is software developer in Japan who awarded Microsoft MVP for Developer Technologies (C#) since July 2012.
