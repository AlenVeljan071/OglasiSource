namespace OglasiSource.Core.Constants
{
    public class Constants
    {

        public static Dictionary<int, string> Currencies = new Dictionary<int, string>
        {
           {1, "EU Euro (€)" },
           {2, "BS Marka (BAM)" }

        };
        public static readonly string[] PermittedFileExtensions = { ".jpg", ".pdf", ".png" };
       

        public static Dictionary<int, string> EntityTypeRating = new Dictionary<int, string>
        {
            {1, "User"},
        };
        public const string User = "User";

        public static Dictionary<int, string> EntityTypeReview = new Dictionary<int, string>
        {
             {1, "User"},
        };

        public const double MinPercentage = 0;
        public const double MaxPercentage = 100;
        public const int NumberOfDays = 7;



        public static Dictionary<int, string> Shifters = new Dictionary<int, string>
        {
           {1, "Automatic" },
           {2, "Manual" },
           {3, "Semi Automatic" }

        };

        public static Dictionary<int, string> Gears = new Dictionary<int, string>
        {
           {1, "3+R" },
           {2, "4+R" },
           {3, "5+R" },
           {4, "6+R" },
           {5, "7+R" },
           {6, "8+R" },
           {7, "9+R" },
           {8, "Other" },

        };

        public static Dictionary<int, string> Emissions = new Dictionary<int, string>
        {
           {1, "Euro 0" },
           {2, "Euro 1" },
           {3, "Euro 2" },
           {4, "Euro 3" },
           {5, "Euro 4" },
           {6, "Euro 5" },
           {7, "Euro 6" }
        };

        public static Dictionary<int, string> Seats = new Dictionary<int, string>
        {
           {1, "1" },
           {2, "2" },
           {3, "3" },
           {4, "4" },
           {5, "5" },
           {6, "6" },
           {7, "7" },
           {8, "8" },
           {9, "More" },

        };

        public static Dictionary<int, string> Colors = new Dictionary<int, string>
        {
           {1, "Yellow" },
           {2, "Orange" },
           {3, "Red" },
           {4, "Silver" },
           {5, "Purple" },
           {6, "Pink" },
           {7, "Brown" },
           {8, "Gray" },
           {9, "Dark Green" },
           {10, "Light Green" },
           {11, "Dark Blue" },
           {12, "Light Blue" },
           {13, "Black" },
           {14, "White" }
        };
    }
}
