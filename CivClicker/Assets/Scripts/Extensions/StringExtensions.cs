using System;

public static class StringExtensions
{
    [Obsolete("Didn't work, made numbers 1.001k lol", true)]
    public static string ConvertToK(this float num)
    {
        if (num >= 1000 && num <= 999999) // more than 1,000 but less than 999,999
        {
            return string.Concat(num / 1000, "k");
        } else
        {
            return num.ToString();
        }
    }
}
