using Newtonsoft.Json;
using Xunit;

namespace XUnitTestProject
{
    public class FloatFormatHandlingTest
    {
        TestModel testModel = new TestModel
        {
            FloatValue = 1.0f,
            NullableFloatValueNUll = null,
            NullableFloatValueNotNull = 1.0f,
            NanFloatValue = float.NaN,
            InfinityFloatValue = float.NegativeInfinity,
            DoubleValue = 1.0d,
            NullableDoubleValueNull = null,
            NullableDoubleValueNotNull = 1.0d,
            NanDoubleValue = double.NaN,
            InfinityDoubleValue = double.NegativeInfinity
        };

        /// <summary>
        /// the same as FloatFormatHandling.String
        /// </summary>
        [Fact]
        public void TheSetting_NotWork_When_DeserializeObject_And__ParamStringIsSerializedFrom_NoneSetting()
        {
            var str = JsonConvert.SerializeObject(testModel);
            Assert.True(str == "{\"FloatValue\":1.0,\"NullableFloatValueNUll\":null,\"NullableFloatValueNotNull\":1.0,\"NanFloatValue\":\"NaN\",\"InfinityFloatValue\":\"-Infinity\",\"DoubleValue\":1.0,\"NullableDoubleValueNull\":null,\"NullableDoubleValueNotNull\":1.0,\"NanDoubleValue\":\"NaN\",\"InfinityDoubleValue\":\"-Infinity\"}");

            //the value has been cahnged after DeserializeObject
            var deserilazation = JsonConvert.DeserializeObject<TestModel>(str);
            Assert.Equal("NaN", deserilazation.NanDoubleValue.ToString());
            Assert.Equal("NaN", deserilazation.NanFloatValue.ToString());
            Assert.True(deserilazation.InfinityDoubleValue == double.NegativeInfinity);
            Assert.True(deserilazation.InfinityFloatValue == float.NegativeInfinity);


            deserilazation = JsonConvert.DeserializeObject<TestModel>(str, new JsonSerializerSettings { FloatFormatHandling = FloatFormatHandling.Symbol });
            Assert.Equal("NaN", deserilazation.NanDoubleValue.ToString());
            Assert.Equal("NaN", deserilazation.NanFloatValue.ToString());
            Assert.True(deserilazation.InfinityDoubleValue == double.NegativeInfinity);
            Assert.True(deserilazation.InfinityFloatValue == float.NegativeInfinity);


            deserilazation = JsonConvert.DeserializeObject<TestModel>(str, new JsonSerializerSettings { FloatFormatHandling = FloatFormatHandling.String });
            Assert.Equal("NaN", deserilazation.NanDoubleValue.ToString());
            Assert.Equal("NaN", deserilazation.NanFloatValue.ToString());
            Assert.True(deserilazation.InfinityDoubleValue == double.NegativeInfinity);
            Assert.True(deserilazation.InfinityFloatValue == float.NegativeInfinity);

        }
        [Fact]
        public void TheSetting_NotWork_When_DeserializeObject_And__ParamStringIsSerializedFrom_DefaultValue()
        {

            var setting = new JsonSerializerSettings
            {
                FloatFormatHandling = FloatFormatHandling.DefaultValue
            };

            var str = JsonConvert.SerializeObject(testModel, setting);
            Assert.True(str == "{\"FloatValue\":1.0,\"NullableFloatValueNUll\":null,\"NullableFloatValueNotNull\":1.0,\"NanFloatValue\":0.0,\"InfinityFloatValue\":0.0,\"DoubleValue\":1.0,\"NullableDoubleValueNull\":null,\"NullableDoubleValueNotNull\":1.0,\"NanDoubleValue\":0.0,\"InfinityDoubleValue\":0.0}");

            //the value has been cahnged after DeserializeObject
            var deserilazation = JsonConvert.DeserializeObject<TestModel>(str);
            Assert.True(deserilazation.NanDoubleValue == 0);
            Assert.True(deserilazation.NanFloatValue == 0);
            Assert.True(deserilazation.InfinityDoubleValue == 0);
            Assert.True(deserilazation.InfinityFloatValue == 0);

            deserilazation = JsonConvert.DeserializeObject<TestModel>(str, setting);
            Assert.True(deserilazation.NanDoubleValue == 0);
            Assert.True(deserilazation.NanFloatValue == 0);
            Assert.True(deserilazation.InfinityDoubleValue == 0);
            Assert.True(deserilazation.InfinityFloatValue == 0);


            deserilazation = JsonConvert.DeserializeObject<TestModel>(str, new JsonSerializerSettings { FloatFormatHandling = FloatFormatHandling.Symbol });
            Assert.True(deserilazation.NanDoubleValue == 0);
            Assert.True(deserilazation.NanFloatValue == 0);
            Assert.True(deserilazation.InfinityDoubleValue == 0);
            Assert.True(deserilazation.InfinityFloatValue == 0);

            deserilazation = JsonConvert.DeserializeObject<TestModel>(str, new JsonSerializerSettings { FloatFormatHandling = FloatFormatHandling.String });
            Assert.True(deserilazation.NanDoubleValue == 0);
            Assert.True(deserilazation.NanFloatValue == 0);
            Assert.True(deserilazation.InfinityDoubleValue == 0);
            Assert.True(deserilazation.InfinityFloatValue == 0);
        }

        [Fact]
        public void TheSetting_NotWork_When_DeserializeObject_And__ParamStringIsSerializedFrom_Symbol()
        {

            var setting = new JsonSerializerSettings
            {
                FloatFormatHandling = FloatFormatHandling.Symbol
            };

            var str = JsonConvert.SerializeObject(testModel, setting);
            Assert.True(str == "{\"FloatValue\":1.0,\"NullableFloatValueNUll\":null,\"NullableFloatValueNotNull\":1.0,\"NanFloatValue\":NaN,\"InfinityFloatValue\":-Infinity,\"DoubleValue\":1.0,\"NullableDoubleValueNull\":null,\"NullableDoubleValueNotNull\":1.0,\"NanDoubleValue\":NaN,\"InfinityDoubleValue\":-Infinity}");

            //the value has been cahnged after DeserializeObject
            var deserilazation = JsonConvert.DeserializeObject<TestModel>(str);
            Assert.Equal("NaN", deserilazation.NanDoubleValue.ToString());
            Assert.Equal("NaN", deserilazation.NanFloatValue.ToString());
            Assert.True(deserilazation.InfinityDoubleValue == double.NegativeInfinity);
            Assert.True(deserilazation.InfinityFloatValue == float.NegativeInfinity);

            deserilazation = JsonConvert.DeserializeObject<TestModel>(str, setting);
            Assert.Equal("NaN", deserilazation.NanDoubleValue.ToString());
            Assert.Equal("NaN", deserilazation.NanFloatValue.ToString());
            Assert.True(deserilazation.InfinityDoubleValue == double.NegativeInfinity);
            Assert.True(deserilazation.InfinityFloatValue == float.NegativeInfinity);


            deserilazation = JsonConvert.DeserializeObject<TestModel>(str, new JsonSerializerSettings { FloatFormatHandling = FloatFormatHandling.Symbol });
            Assert.Equal("NaN", deserilazation.NanDoubleValue.ToString());
            Assert.Equal("NaN", deserilazation.NanFloatValue.ToString());
            Assert.True(deserilazation.InfinityDoubleValue == double.NegativeInfinity);
            Assert.True(deserilazation.InfinityFloatValue == float.NegativeInfinity);

            deserilazation = JsonConvert.DeserializeObject<TestModel>(str, new JsonSerializerSettings { FloatFormatHandling = FloatFormatHandling.String });
            Assert.Equal("NaN", deserilazation.NanDoubleValue.ToString());
            Assert.Equal("NaN", deserilazation.NanFloatValue.ToString());
            Assert.True(deserilazation.InfinityDoubleValue == double.NegativeInfinity);
            Assert.True(deserilazation.InfinityFloatValue == float.NegativeInfinity);
        }

        /// <summary>
        /// default is FloatFormatHandling.String
        /// </summary>
        [Fact]
        public void TheSetting_NotWork_When_DeserializeObject_And__ParamStringIsSerializedFrom_String()
        {
            var setting = new JsonSerializerSettings
            {
                FloatFormatHandling = FloatFormatHandling.String
            };

            var str = JsonConvert.SerializeObject(testModel, setting);
            Assert.True(str == "{\"FloatValue\":1.0,\"NullableFloatValueNUll\":null,\"NullableFloatValueNotNull\":1.0,\"NanFloatValue\":\"NaN\",\"InfinityFloatValue\":\"-Infinity\",\"DoubleValue\":1.0,\"NullableDoubleValueNull\":null,\"NullableDoubleValueNotNull\":1.0,\"NanDoubleValue\":\"NaN\",\"InfinityDoubleValue\":\"-Infinity\"}");

            //the value has been cahnged after DeserializeObject
            var deserilazation = JsonConvert.DeserializeObject<TestModel>(str);
            Assert.Equal("NaN", deserilazation.NanDoubleValue.ToString());
            Assert.Equal("NaN", deserilazation.NanFloatValue.ToString());
            Assert.True(deserilazation.InfinityDoubleValue == double.NegativeInfinity);
            Assert.True(deserilazation.InfinityFloatValue == float.NegativeInfinity);

            deserilazation = JsonConvert.DeserializeObject<TestModel>(str, setting);
            Assert.Equal("NaN", deserilazation.NanDoubleValue.ToString());
            Assert.Equal("NaN", deserilazation.NanFloatValue.ToString());
            Assert.True(deserilazation.InfinityDoubleValue == double.NegativeInfinity);
            Assert.True(deserilazation.InfinityFloatValue == float.NegativeInfinity);


            deserilazation = JsonConvert.DeserializeObject<TestModel>(str, new JsonSerializerSettings { FloatFormatHandling = FloatFormatHandling.Symbol });
            Assert.Equal("NaN", deserilazation.NanDoubleValue.ToString());
            Assert.Equal("NaN", deserilazation.NanFloatValue.ToString());
            Assert.True(deserilazation.InfinityDoubleValue == double.NegativeInfinity);
            Assert.True(deserilazation.InfinityFloatValue == float.NegativeInfinity);

            deserilazation = JsonConvert.DeserializeObject<TestModel>(str, new JsonSerializerSettings { FloatFormatHandling = FloatFormatHandling.String });
            Assert.Equal("NaN", deserilazation.NanDoubleValue.ToString());
            Assert.Equal("NaN", deserilazation.NanFloatValue.ToString());
            Assert.True(deserilazation.InfinityDoubleValue == double.NegativeInfinity);
            Assert.True(deserilazation.InfinityFloatValue == float.NegativeInfinity);
        }
        [Fact]
        public void DefaultValueTest()
        {

            var setting = new JsonSerializerSettings
            {
                FloatFormatHandling = FloatFormatHandling.DefaultValue
            };

            var str = JsonConvert.SerializeObject(testModel, setting);
            Assert.True(str == "{\"FloatValue\":1.0,\"NullableFloatValueNUll\":null,\"NullableFloatValueNotNull\":1.0,\"NanFloatValue\":0.0,\"InfinityFloatValue\":0.0,\"DoubleValue\":1.0,\"NullableDoubleValueNull\":null,\"NullableDoubleValueNotNull\":1.0,\"NanDoubleValue\":0.0,\"InfinityDoubleValue\":0.0}");
        }

        [Fact]
        public void SymbolTest()
        {
            var setting = new JsonSerializerSettings
            {
                FloatFormatHandling = FloatFormatHandling.Symbol
            };


            var str = JsonConvert.SerializeObject(testModel, setting);
            Assert.True(str == "{\"FloatValue\":1.0,\"NullableFloatValueNUll\":null,\"NullableFloatValueNotNull\":1.0,\"NanFloatValue\":NaN,\"InfinityFloatValue\":-Infinity,\"DoubleValue\":1.0,\"NullableDoubleValueNull\":null,\"NullableDoubleValueNotNull\":1.0,\"NanDoubleValue\":NaN,\"InfinityDoubleValue\":-Infinity}");
        }

        /// <summary>
        /// NonAscii is like 你好
        /// </summary>
        [Fact]
        public void StringTest()
        {
            var setting = new JsonSerializerSettings
            {
                FloatFormatHandling = FloatFormatHandling.String
            };

            var str = JsonConvert.SerializeObject(testModel, setting);
            Assert.True(str == "{\"FloatValue\":1.0,\"NullableFloatValueNUll\":null,\"NullableFloatValueNotNull\":1.0,\"NanFloatValue\":\"NaN\",\"InfinityFloatValue\":\"-Infinity\",\"DoubleValue\":1.0,\"NullableDoubleValueNull\":null,\"NullableDoubleValueNotNull\":1.0,\"NanDoubleValue\":\"NaN\",\"InfinityDoubleValue\":\"-Infinity\"}");
        }
    }

    class TestModel
    {
        public float FloatValue { set; get; }
        public float? NullableFloatValueNUll { set; get; }
        public float? NullableFloatValueNotNull { set; get; }
        public float NanFloatValue { set; get; }
        public float InfinityFloatValue { set; get; }

        public double DoubleValue { set; get; }
        public double? NullableDoubleValueNull { set; get; }
        public double? NullableDoubleValueNotNull { set; get; }
        public double NanDoubleValue { set; get; }
        public double InfinityDoubleValue { set; get; }
    }
}
