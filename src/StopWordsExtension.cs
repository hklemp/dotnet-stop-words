using System;
using System.Linq;
using System.Globalization;

namespace StopWord
{
    public static class StopWordsExtension
    {
		public static string RemoveStopWords(this string s)
        {

            return Remove(s, CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
        }

		public static string RemoveStopWords(this string s, string shortLanguageName)
        {
			return Remove(s, shortLanguageName);
        }

		public static string RemoveStopWords(this string s, CultureInfo cultureInfo )
        {
			return Remove(s, cultureInfo.TwoLetterISOLanguageName);
        }
        
		private static string Remove(string s,string shortLanguageName)
		{
			var stopWordList = StopWords.GetStopWords(shortLanguageName);
            s = s.Split(' ').Where(x => !stopWordList.Contains(x)).DefaultIfEmpty().Aggregate((current, next) => current + " " + next);
			
            return s  ?? String.Empty;
		}
    }
}
