namespace BoringNews;

public static class Utility
{
    /// <summary>
    /// Converts a Unix timestamp to a DateTime in local time
    /// </summary>
    /// <param name="unixTimestamp">A Unix timestamp represented as an integer</param>
    /// <returns>A DateTime using the local time zone</returns>
    public static DateTime ToLocalDateTime(this int unixTimestamp)
    {
        return DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).LocalDateTime;
    }
}