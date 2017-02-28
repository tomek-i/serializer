using System;
using System.Collections.Generic;
using NUnit.Framework;
using TI.Serializer.Logic.Serializers;

namespace TISerializer.UnitTests
{
    [TestFixture]
    public class JsonSerializerTests
    {
        internal abstract class AbstractTest
        {
            public string Name { get; set; }   
        }

        internal class ConcreteTest : AbstractTest
        {
            public ConcreteTest()
            {
                Name = "Concrete";
            }
        }
        internal interface ITestInterface
        {
            int Value { get; set; }
        }
        internal class TestObject: ITestInterface
        {
            public int Value { get; set; }
        }
        [Test]
        public void Deserialize_SerializedString_NotNull()
        {
            //Deserialize(serialized string)
            JsonSerializer serialiser = new JsonSerializer();
          string expected = "{\"Value\":1}";
           

            //ACT
             object result = serialiser.Deserialize(expected, typeof(TestObject));
            //ASSERT
            Assert.IsNotNull(result);
        }

        [Test]
        public void Deserialize_Abstract_ExpectedBehaviour()
        {
            //ARRANGE
            JsonSerializer serializer = new JsonSerializer();
            string expected = "{\"Value\":1}";


            //ASSER
            Assert.Throws<ArgumentException>(
                delegate
                {
                    //ACT
                    serializer.Deserialize<AbstractTest>(expected);
                });


        }
        [Test]
        public void Deserialize_Interface_ExpectedBehaviour()
        {
            //ARRANGE
            JsonSerializer serializer = new JsonSerializer();
            string expected = "{\"Value\":1}";

           
            //ASSER
            Assert.Throws<ArgumentException>(
                delegate
                {
                    //ACT
                    serializer.Deserialize<ITestInterface>(expected);
                });
           
        }
        [Test]
        public void Deserialize_SerializedString_ReturnsObject()
        {
            //Deserialize(serialized string)
            JsonSerializer serialiser = new JsonSerializer();
            string expected = "{\"Value\":1}";
            


            //ACT
            object result = serialiser.Deserialize(expected, typeof(TestObject));
            //ASSERT
            Assert.IsInstanceOf<object>(result);
        }
        [Test]
        public void Deserialize_SerializedString_IsOfExpectedType()
        {
            //Deserialize(serialized string)
            JsonSerializer serialiser = new JsonSerializer();
            string expected = "{\"Value\":1}";
            


            //ACT
            object result = serialiser.Deserialize(expected,typeof(TestObject));
            //ASSERT
            Assert.IsInstanceOf<TestObject>(result);
        }
        [Test]
        public void Deserialize_RandomString_Throws()
        {
            //ARRANGE
            JsonSerializer serializer = new JsonSerializer();
            string underTest = "abc";


            try
            {
                //ACT
                serializer.Deserialize(underTest);
            }
            catch (Exception)
            {
               Assert.Pass();
                return;
            }
            Assert.Fail("Exception expected");
            
            
           
        }
        [Test]
        public void Serialize_ValidObject_ReturnsString()
        {
            //ARRANGE
            JsonSerializer serializer = new JsonSerializer();
            string expected = "{\"Value\":1}";
            TestObject underTest = new TestObject() {Value = 1};
            //ACT
            string result = serializer.Serialize(underTest, Format.None);
            
            //ASSERT
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Deserialize_Type_IsInstanceOfType()
        {
            //ARRANGE
            JsonSerializer serializer = new JsonSerializer();
            string expected = "{\"Value\":1}";
            //TestObject underTest = new TestObject() { Value = 1 };
            //ACT
            TestObject result = serializer.Deserialize<TestObject>(expected);
            //ASSERT
            Assert.IsInstanceOf<TestObject>(result);
           
        }
        [Test]
        public void Deserialize_Type_ValueIsSet()
        {
            //ARRANGE
            JsonSerializer serializer = new JsonSerializer();
            string expected = "{\"Value\":1}";
            //TestObject underTest = new TestObject() { Value = 1 };
            //ACT
            TestObject result = serializer.Deserialize<TestObject>(expected);
            //ASSERT
            Assert.AreEqual(1,result.Value);

        }
        [Test]
        public void Deserialize_Type_IsNotNull()
        {
            //ARRANGE
            JsonSerializer serializer = new JsonSerializer();
            string expected = "{\"Value\":1}";
            //TestObject underTest = new TestObject() { Value = 1 };
            //ACT
            TestObject result = serializer.Deserialize<TestObject>(expected);
            //ASSERT
            Assert.NotNull(result);

        }

    }
}