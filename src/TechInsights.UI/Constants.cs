﻿namespace TechInsights.UI
{
    public static class Constants
    {
        public static class Timers
        {
            public const int Spinner = 1500;
        }

        public static class Global
        {
            public const string AUTHOR = "Nuno Silva";
            public const string COPYRIGHT = "NunoSilva";
            public const string SITE_NAME = "Tech Insights.";
            public const string DESCRIPTION = "description";
        }

        public static class Contact
        {
            public const string EMAIL = "nuno.mogas@gmail.com";
            public const string PHONE = "+44 7475 1246 68";
        }

        public static class SocialLinks
        {
            public const string LINKEDIN = "https://www.linkedin.com/in/nunomogas/";
            public const string GITHUB = "https://github.com/mogas";
            public const string BITBUCKET = "https://bitbucket.org/nmogas/";
            public const string FACEBOOK = "https://www.facebook.com/nunomogassilva";
            public const string INSTAGRAM = "https://www.instagram.com/nmogas/";
        }

        public static class Routes
        {
            public const string BlogPost = "/blog/{slug?}";
            public const string BlogPostByCategory = "/blog/category/{category}/{page:int?}";
        }
    }
}
