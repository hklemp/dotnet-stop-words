using System;
using Xunit;
using StopWord;
using System.Globalization;

namespace StopWord
{
    public class StopWordsTests
    {
        [Fact]
		public void GetStopWordsCurrentCultureTest()
        {
			
			CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
			CultureInfo.CurrentCulture = culture;
			var r = StopWords.GetStopWords();
			Assert.NotNull(r);
        }
      
		[Fact]
        public void GetStopWordsForENTest()
        {
			var r = StopWords.GetStopWords("en");
			var count = 0;

			if(r != null)
				count = r.Length;

            Assert.Equal(1298,count);
        }
 
		[Fact]
		public void RemoveStopWordsTest()
        {
			var s = "Hello this is a test";
			var exepted = "Hello";

			var r = s.RemoveStopWords("en");

       		Assert.Equal(exepted, r);
        }

        [Fact]
        public void RemoveAllWordsTest()
        {
            var s = "this is a test";
            var exepted = String.Empty;

            var r = s.RemoveStopWords("en");

            Assert.Equal(exepted, r);
        }
    }
}
