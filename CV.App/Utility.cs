using System.Text.RegularExpressions;

namespace CV.App
{
    public static class Utility
    {
        public static string GetClearQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return string.Empty;
            }

            query = query.Trim();
            query = Regex.Replace(query, @"[^\w\sа-яА-Я]", " ");
            return Regex.Replace(query, @"\s+", " ");
        }
    }
}
