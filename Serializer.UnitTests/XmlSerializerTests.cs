using System;

using Moq;
using NUnit.Framework;
using TI.Serializer.Logic.Serializers;


namespace TISerializer.UnitTests
{
    [TestFixture]
    public class XmlSerializerTests
    {
       
        [Test]
        public void DeserializeTYPE_StringSerializedXmlString_ReturnsString()
        {
            //ARRANGE
            XmlSerializer ser = new XmlSerializer();
            //ACT
            object result = ser.Deserialize<string>("<string>1</string>");
            //ASSERT
            Assert.AreEqual("1", result);
        }


        [Test]
        public void Deserialize_NotPassingTheType_Throws()
        {
            //ARRANGE
            XmlSerializer ser = new XmlSerializer();

            //ASSERT
            Assert.Throws(
                Is.TypeOf<NullReferenceException>()
                    .And.Message.EqualTo("The type cannot be null."),
                 
                delegate
                {
                    //ACT
                    ser.Deserialize(It.IsAny<string>());
                });
        }

        [Test]
        public void Deserialize_StringSerializedXmlString_ReturnsString()
        {
            //ARRANGE
            XmlSerializer ser = new XmlSerializer();
            //ACT
            object result = ser.Deserialize("<string>1</string>", typeof(string));
            //ASSERT
            Assert.AreEqual("1", result);
        }

        [Test]
        public void Deserialize_IntSerializedXmlString_ReturnsInteger()
        {
            //ARRANGE
            XmlSerializer ser = new XmlSerializer();
            //ACT
            object result = ser.Deserialize("<int>1</int>",typeof(int));
            //ASSERT
            Assert.AreEqual(1,result);
        }

        [Test]
        public void Serialize_AnyInt_ContainsIntXMLtags()
        {
            //ARRANGE
            XmlSerializer ser = new XmlSerializer();

            //ACT
            string result = ser.Serialize(It.IsAny<int>());
            
            //ASSERT
            StringAssert.Contains("<int>", result);
            StringAssert.Contains("</int>",result);
        }
    }
}