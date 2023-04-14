using OglasiSource.Core.Constants;

namespace OglasiSource.Api.Helpers
{
    public class Calculations
    {
        public static int? CalculateDays(DateTime? startDate, DateTime? endDate)
        {
            int? days = (endDate - startDate)?.Days;
            return (days > 0) ? days : days * (-1);
        }
        public static double? CalculatePercentage(DateTime? startDate, DateTime? endDate)
        {
            if (DateTime.UtcNow < endDate && DateTime.UtcNow > startDate)
            {
                double? percentage = (startDate != null && startDate != endDate) ? ((double)CalculateDays(startDate, DateTime.UtcNow)! / (double)CalculateDays(startDate, endDate)!) * 100 : null;
                return (percentage != null) ? Math.Round((double)percentage, 2) : null;
            }
            else if (DateTime.UtcNow > endDate)
            {
                return Constants.MaxPercentage;
            }
            else if (DateTime.UtcNow < startDate)
            {
                return Constants.MinPercentage;
            }
            else
            {
                return null;
            }
        }
        public static int Generate4digit()
        {
            Random code = new Random();
            return code.Next(1000, 9999);
        }
        public static string TimeStringFromMinutes(double totalMinutes)
        {
            var resultSpan = TimeSpan.FromMinutes(totalMinutes);
            var days = (int)resultSpan.Days;
            var hours = (int)resultSpan.Hours;
            var minutes = resultSpan.Minutes;

            string result = string.Empty;
            if (days > 0)
            {
                result = $"{days}d.{hours}h.{minutes}m.";
            }
            else
            {
                if (minutes > 0)
                {
                    result = $"{hours}h.{minutes}m.";
                }
                else
                {
                    result = $"{minutes}m.";
                }
            }

            return result;
        }

    }
}
