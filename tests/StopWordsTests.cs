using System;
using Xunit;
using StopWord;
using System.Globalization;

namespace StopWord
{
    public class StopWordsTests
    {
        [Fact]
        public void GetStopWords_ForCurrentCulture_ShouldBeNotNull()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
            CultureInfo.CurrentCulture = culture;
            var r = StopWords.GetStopWords();
            Assert.NotNull(r);
        }

        [Theory]
        [InlineData("en", 1298)]
        public void GetStopWords_ForEN_ShouldReturnNoOfWords(string lang, int noOfWords)
        {
            var r = StopWords.GetStopWords(lang);

            Assert.NotNull(r);
            Assert.Equal(noOfWords, r.Length);
        }

        [Theory]
        [InlineData("this is a test","")]
        [InlineData("Hello this is a test", "Hello")]
        public void RemoveStopWords_ShouldEqualsExpected(string text, string expected)
        {
            var cleandText = text.RemoveStopWords("en");
            Assert.Equal(expected, cleandText);
        }
    }
}
