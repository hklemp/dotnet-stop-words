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

			Assert.Equal(174,count);
        }
  

		[Fact]
		public void RemoveStopWordsTest()
        {
			var s = "Hello this is a test";
			var exepted = "Hello test";

			var r = s.RemoveStopWords("en");

       		Assert.Equal(exepted, r);
        }      
    }
}
