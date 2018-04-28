using Newtonsoft.Json;
using Xunit;

namespace XUnitTestProject
{
    public class StringEscapeHandlingTest
    {
        string strTest = "12<>.\r\n你好hello";

        [Fact]
        public void DefaultTest()
        {
            var setting = new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.Default
            };

            var str = JsonConvert.SerializeObject(strTest, setting);
            Assert.True(str == "\"12<>.\\r\\n你好hello\"");

        }

        /// <summary>
        /// Html is like <>
        /// </summary>
        [Fact]
        public void EscapeHtmlTest()
        {
            var setting = new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeHtml
            };


            var str = JsonConvert.SerializeObject(strTest, setting);
            Assert.True(str == "\"12\\u003c\\u003e.\\r\\n你好hello\"");

            var deserilazation1 = JsonConvert.DeserializeObject("\"12\\u003c\\u003e.\\r\\n你好hello\"");
            var deserilazation2 = JsonConvert.DeserializeObject("\"12\\u003c\\u003e.\\r\\n你好hello\"", setting);
        
            Assert.True(strTest == deserilazation1.ToString());
            Assert.True(strTest == deserilazation2.ToString());
        }

        /// <summary>
        /// NonAscii is like 你好
        /// </summary>
        [Fact]
        public void EscapeNonAsciiTest()
        {
            var setting = new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            };


            var str = JsonConvert.SerializeObject(strTest, setting);
            Assert.True(str == "\"12<>.\\r\\n\\u4f60\\u597dhello\"");

            var deserilazation1 = JsonConvert.DeserializeObject("\"12<>.\\r\\n\\u4f60\\u597dhello\"", setting);
            var deserilazation2 = JsonConvert.DeserializeObject("\"12<>.\\r\\n\\u4f60\\u597dhello\"");

            Assert.True(strTest == deserilazation1.ToString());
            Assert.True(strTest == deserilazation2.ToString());
        }
    }
}
