using System;



namespace XSitemaps
{
    /// <summary>
    /// Represents how frequently the page is likely to change.
    /// </summary>
    public enum ChangeFrequency
    {
        Always = 0,
        Hourly,
        Daily,
        Weekly,
        Monthly,
        Yearly,
        Never,
    }



    /// <summary>
    /// Provides <see cref="ChangeFrequency"/> extension methods.
    /// </summary>
    internal static class ChangeFrequencyExtensions
    {
        /// <summary>
        /// Converts to parameter value string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToParameter(this ChangeFrequency value)
            => value switch
            {
                ChangeFrequency.Always => "always",
                ChangeFrequency.Hourly => "hourly",
                ChangeFrequency.Daily => "daily",
                ChangeFrequency.Weekly => "weekly",
                ChangeFrequency.Monthly => "monthly",
                ChangeFrequency.Yearly => "yearly",
                ChangeFrequency.Never => "never",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
    }
}
