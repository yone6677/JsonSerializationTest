using Newtonsoft.Json;
using Xunit;

namespace XUnitTestProject
{
    public class JsonConvert_SerializeObjectTest
    {
        [Fact]
        public void SerializeObject_OnlyWithValueArgument()
        {
            var testObject = new object();
            var str = JsonConvert.SerializeObject(testObject);
            Assert.True(str == "{}");

            str = JsonConvert.SerializeObject(null);
            Assert.True(str == "null");

            str = JsonConvert.SerializeObject(1);
            Assert.True(str == "1");

            str = JsonConvert.SerializeObject("1");
            Assert.True(str == "\"1\"");

            str = JsonConvert.SerializeObject(new User());
            Assert.True(str == "{\"Id\":0,\"Name\":null,\"Sex\":0}");

            str = JsonConvert.SerializeObject(new User
            {
                Id = 1,
                Name = "Redy",
                Sex = Sex.Male
            });
            Assert.True(str == "{\"Id\":1,\"Name\":\"Redy\",\"Sex\":0}");
        }
    }
}
