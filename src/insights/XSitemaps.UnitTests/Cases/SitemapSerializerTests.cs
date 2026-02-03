using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using XSitemaps;

namespace XSitemaps.UnitTests.Cases;



[TestClass]
public sealed class SitemapSerializerTests
{
    [TestMethod]
    public void Serialize_Sitemap()
    {
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
        string[] expects
            = [
                """
                ﻿<?xml version="1.0" encoding="utf-8"?>
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
                """,
                """
                ﻿<?xml version="1.0" encoding="utf-8"?>
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
                """,
            ];
        foreach (var (index, sitemap) in sitemaps.Index())
        {
            var actual = toXmlString(sitemap);
            var expect = expects[index];
            actual.ShouldBe(expect);
        }

        #region Local functions
        static string toXmlString(Sitemap sitemap)
        {
            using (var stream = new MemoryStream())
            {
                var options = new SitemapSerializerOptions { EnableIndent = true };
                SitemapSerializer.Serialize(stream, sitemap, options);
                var bytes = stream.ToArray();
                return Encoding.UTF8.GetString(bytes);
            }
        }
        #endregion
    }
}
