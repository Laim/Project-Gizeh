public static class NumberExtensions
{
    /// <summary>
    /// Returns the integer value of a percentage
    /// </summary>
    /// <param name="value">Example: 1000</param>
    /// <param name="percentage">Example: 10</param>
    /// <returns>
    ///     Example: 100
    /// </returns>
    public static float Percentage(this float value, float percentage)
    {
        return (value * percentage) / 100;
    }
}
