using Newtonsoft.Json;
using Xunit;

namespace XUnitTestProject
{
    public class FloatParseHandlingTest
    {

        /// <summary>
        /// 使用非泛型DeserializeObject，结果的精度由setting决定
        /// </summary>
        [Fact]
        public void LostPrecision_When_DeserializeObject_UseDouble()
        {

            var settingDecimal = new JsonSerializerSettings
            {
                FloatParseHandling = FloatParseHandling.Decimal
            };

            var settingDouble = new JsonSerializerSettings
            {
                FloatParseHandling = FloatParseHandling.Double
            };

            //15 places
            var precision15Default = JsonConvert.DeserializeObject("1.999999999999999").ToString();
            var precision15Double = JsonConvert.DeserializeObject("1.999999999999999", settingDouble).ToString();
            var precision15Decimal = JsonConvert.DeserializeObject("1.999999999999999", settingDecimal).ToString();

            Assert.NotEqual("1.999999999999999", precision15Default);
            Assert.Equal("2", precision15Default);

            Assert.NotEqual("1.999999999999999", precision15Double);
            Assert.Equal("2", precision15Double);

            Assert.Equal("1.999999999999999", precision15Decimal);
        }

        /// <summary>
        /// 使用泛型DeserializeObject<T>,结果的精度由T决定
        /// </summary>
        [Fact]
        public void Setting_NotWork_When_DeserializeObjectT()
        {

            var settingDecimal = new JsonSerializerSettings
            {
                FloatParseHandling = FloatParseHandling.Decimal
            };

            var settingDouble = new JsonSerializerSettings
            {
                FloatParseHandling = FloatParseHandling.Double
            };

            var decimalDo = JsonConvert.DeserializeObject<decimal>("1.999999999999999", settingDouble);
            var decimalDe = JsonConvert.DeserializeObject<decimal>("1.999999999999999", settingDecimal);
            Assert.Equal(1.999999999999999m, decimalDo);
            Assert.Equal(1.999999999999999m, decimalDe);

            //15 places
            var doubleDo = JsonConvert.DeserializeObject<double>("1.999999999999999", settingDouble);
            var doubleDe = JsonConvert.DeserializeObject<double>("1.999999999999999", settingDecimal);
            Assert.Equal(1.9999999999999989, doubleDo);//result has 16 places
            Assert.Equal(1.9999999999999989, doubleDe);//result has 16 places

            //16 places
            doubleDo = JsonConvert.DeserializeObject<double>("1.9999999999999999", settingDouble);
            doubleDe = JsonConvert.DeserializeObject<double>("1.9999999999999999", settingDecimal);
            Assert.Equal(2, doubleDo);
            Assert.Equal(2, doubleDe);
        }
    }
}
