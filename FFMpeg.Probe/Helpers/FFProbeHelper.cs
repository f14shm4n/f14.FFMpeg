using System;
using System.Globalization;

namespace FFMpeg.Probe.Helpers
{
    internal static class FFProbeHelper
    {
        public static int Gcd(int first, int second)
        {
            while (first != 0 && second != 0)
            {
                if (first > second)
                    first -= second;
                else second -= first;
            }
            return first == 0 ? second : first;
        }

        public static TimeSpan ParseDuration(string durationStr)
        {
            return TimeSpan.FromSeconds(double.TryParse(durationStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var output) ? output : 0);
        }
    }
}
