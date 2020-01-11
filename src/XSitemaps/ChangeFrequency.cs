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
        {
            switch (value)
            {
                case ChangeFrequency.Always: return "always";
                case ChangeFrequency.Hourly: return "hourly";
                case ChangeFrequency.Daily: return "daily";
                case ChangeFrequency.Weekly: return "weekly";
                case ChangeFrequency.Monthly: return "monthly";
                case ChangeFrequency.Yearly: return "yearly";
                case ChangeFrequency.Never: return "never";
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
