using System;

namespace XSitemaps;



/// <summary>
/// Represents URL entry of sitemap.xml.
/// </summary>
/// <param name="location">URL of the page.</param>
/// <param name="modifiedAt">The date of last modification of the file.</param>
/// <param name="frequency">How frequently the page is likely to change.</param>
/// <param name="priority">The priority of this URL relative to other URLs on your site.</param>
public sealed class SitemapUrl(string location, DateTimeOffset? modifiedAt = null, ChangeFrequency? frequency = null, double? priority = null)
{
    #region Properties
    /// <summary>
    /// Gets URL of the page.
    /// This URL must begin with the protocol (such as http) and end with a trailing slash, if your web server requires it.
    /// This value must be less than 2,048 characters.
    /// </summary>
    public string Location { get; } = location;


    /// <summary>
    /// Gets the date of last modification of the file.
    /// </summary>
    public DateTimeOffset? LastModifiedAt { get; } = modifiedAt;


    /// <summary>
    /// Gets how frequently the page is likely to change.
    /// </summary>
    public ChangeFrequency? ChangeFrequency { get; } = frequency;


    /// <summary>
    /// Gets the priority of this URL relative to other URLs on your site.
    /// Valid values range from 0.0 to 1.0.
    /// This value does not affect how your pages are compared to pages on other sites—it only lets the search engines know which pages you deem most important for the crawlers.
    /// </summary>
    public double? Priority { get; } = priority;
    #endregion
}
