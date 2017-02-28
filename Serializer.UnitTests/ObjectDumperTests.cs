using System.Collections.Generic;
using NUnit.Framework;
using TI.Serializer.Logic.Serializers;

namespace TISerializer.UnitTests
{
    [TestFixture]
    public class ObjectDumperTests
    {

        internal class TestObject
        {
            public int Value { get; set; } = 1;
        }
        internal class TestObject2
        {
            public int Value { get; set; } = 1;
            public string Text { get; set; } = "abc";
        }
        internal class TestObject3
        {
            public int Value { get; set; } = 1;
            public string Text { get; set; } = "abc";
            public List<int> List { get; set; } = new List<int>() { 1,2,3};

            public TestObject2 Obj = new TestObject2();
        }

        [Test]
        public void Serialize_Primitive_ReturnsPrimitiveAsString()
        {
            //ARRANGE
            var dumper = new ObjectDumper();
            //ACT
            var result = dumper.Serialize(1);
            //ASSERT
            Assert.AreEqual("1\r\n",result);
        }
        [Test]
        public void Serialize_SimpleClass_ReturnsString()
        {
            //ARRANGE
            TestObject underTest = new TestObject();
            var dumper = new ObjectDumper();
            //ACT
            var result = dumper.Serialize(underTest);
            //ASSERT
            Assert.AreEqual("Value=1\r\n", result);
        }
        [Test]
        public void Serialize_ComplexClass_ReturnsString()
        {
            //ARRANGE
            TestObject2 underTest = new TestObject2();
            var dumper = new ObjectDumper();
            //ACT
            var result = dumper.Serialize(underTest);
            //ASSERT
            Assert.AreEqual("Value=1         Text=abc\r\n", result);
        }
        [Test]
        public void Serialize_ComplexClassWithSUblevel_ReturnsString()
        {
            //ARRANGE
            var underTest = new List<int>() {1,2,3};
            var dumper = new ObjectDumper();
            //ACT
            var result = dumper.Serialize(underTest);
            //ASSERT
            Assert.AreEqual("1\r\n2\r\n3\r\n", result);
        }
    }
}