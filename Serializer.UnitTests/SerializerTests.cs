using System;
using Moq;
using NUnit.Framework;
using TI.Serializer.Logic.API;


namespace TISerializer.UnitTests
{
    [TestFixture]
    public class SerializerTests
    {
        [Test]
        public void DeserializeTYPE_AnyString_ReturnsTYPE()
        {
            //ARRANGE
            Mock<ISerializer> mock = new Mock<ISerializer>(MockBehavior.Default);
            mock.Setup(ser => ser.Deserialize<object>(It.IsAny<string>())).Returns(It.IsAny<object>());
            
            //ACT
            mock.Object.Deserialize<object>(It.IsAny<string>());
            
            //ASSERT
            mock.Verify(s => s.Deserialize<object>(It.IsAny<string>()));
        }
            

        [Test]
        public void Deserialize_AnyStringWithTypeNull_ReturnsAnyObject()
        {
            //ARRANGE
            Mock<ISerializer> mock = new Mock<ISerializer>(MockBehavior.Default);
            mock.Setup(ser => ser.Deserialize(It.IsAny<string>(),null)).Returns(It.IsAny<object>());

            //ACT
            mock.Object.Deserialize(It.IsAny<string>());

            //ASSERT
            mock.Verify(s => s.Deserialize(It.IsAny<string>(),null));
        }

        [Test]
        public void Deserialize_AnyStringAnyType_ReturnsAnyObject()
        {
            //ARRANGE
            Mock<ISerializer> mock = new Mock<ISerializer>(MockBehavior.Default);
            mock.Setup(ser => ser.Deserialize(It.IsAny<string>(),It.IsAny<Type>())).Returns(It.IsAny<Object>());
            
            //ACT
            mock.Object.Deserialize(It.IsAny<string>(), It.IsAny<Type>());

            //ASSERT
            mock.Verify(s => s.Deserialize(It.IsAny<string>(), It.IsAny<Type>()));
        }

        [Test]
        public void Serialize_AnyObject_ReturnsAnyString()
        {
            //ARRANGE
            Mock<ISerializer> mock = new Mock<ISerializer>(MockBehavior.Default);
            mock.Setup(ser => ser.Serialize(It.IsAny<object>())).Returns(It.IsAny<string>());

            //ACT
            mock.Object.Serialize(It.IsAny<object>());

            //ASSERT
            mock.Verify(s => s.Serialize(It.IsAny<object>()));
        }
    }
}
