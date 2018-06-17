using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace StopWord
{
    public  static class StopWords
    {

		public static string[] GetStopWords()
        {
            var currentCulture = CultureInfo.CurrentCulture;
            return GetStopWords(currentCulture);
        }

		public static string[] GetStopWords(CultureInfo culture)
        {
            return GetStopWords(culture.TwoLetterISOLanguageName);
        }

		public static  string[] GetStopWords(string shortLanguageName)
        {
            var fullLanguageName = mapLanguage(shortLanguageName);
            return LoadStopWords(fullLanguageName);
        }



		private  static string mapLanguage(string shortLanguageName)
        {
            var langJson = LoadLanguages();
            var data = (JObject)JsonConvert.DeserializeObject(langJson);
            if (data[shortLanguageName] == null)
            {
                throw new ArgumentException(String.Format("The language {0} is not supported", shortLanguageName));
            }

            var result = data[shortLanguageName].Value<string>();
            return result;
        }

		private static string[] LoadStopWords(string lang)
        {
			var resourceName = String.Format("StopWord.data.{0}.txt", lang);
            var data = LoadData(resourceName);

            var result = data.Split(new[] { "\r\n", "\r", "\n" },
                       StringSplitOptions.None);
            result = result.Where(x => !String.IsNullOrEmpty(x)).ToArray();
            return result;
        }

		private static string LoadLanguages()
        {
			var resourceName = "StopWord.data.languages.json";
            var result = LoadData(resourceName);
            return result;
        }

		private static string LoadData(string resourceName)
        {
            string result = String.Empty;
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

    }
}
