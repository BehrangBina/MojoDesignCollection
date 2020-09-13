using System;
using System.Text.RegularExpressions;

namespace MojoDesignCollection.Models.Helper
{
    public  class QueryString
    {
        public static int GetPageNumber(string returnUrl)
        {
            int productPage = 1;
            var pattern = @"(productPage=)\d+";
            Regex rx = new Regex(pattern,RegexOptions.IgnoreCase);
            var m = rx.Match(returnUrl);
            if (m.Success)
            {
                productPage = Convert.ToInt32(m.Value.Replace("productPage=", ""));
            }
            return productPage;
        }

        public static string GetCategory(string returnUrl)
        {
            string category = "";
            var pattern = @"(category=)[a-zA-Z]+";
            Regex rx = new Regex(pattern,RegexOptions.IgnoreCase);
            var m = rx.Match(returnUrl);
            if (m.Success)
            {
                category = m.Value.Replace("category=", "");
            }

            var categoryEnum = Convertor.StringToCategoryEnum(category);
            return categoryEnum.ToString();
        }
    }
}
