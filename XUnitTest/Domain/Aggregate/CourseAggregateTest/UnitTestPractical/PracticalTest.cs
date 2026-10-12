using Domain.Aggreagtes.CourseAggregate;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestTopic;

namespace XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestPractical
{
    public class PracticalTest
    {
        [Fact]
        public void Constructor_ShouldSetProperties_WhenValidParametersAreProvided()
        {
            //Arrange
            //Act
            Pratical praticalObject = new Pratical(PracticalData.Name, TopicData.TopicId, PracticalData.Link, PracticalData.Content);

            //Assert

            Assert.Equal(PracticalData.Name, praticalObject.Name);
            Assert.StartsWith("Bubble", PracticalData.Name);
            Assert.Equal(TopicData.TopicId, praticalObject.TopicId);
            Assert.Equal(PracticalData.Link, praticalObject.Link);
            Assert.Equal(PracticalData.Content, praticalObject.Content);
        }
        [Theory]
        [InlineData("Name", null, "00000000-0000-0000-0000-000000000000", "Pratical name cannot be null or empty")]
        [InlineData("TopicId", "", "00000000-0000-0000-0000-000000000000", "Topic Id cannot be empty")]
        [InlineData("Link", "", "00000000-0000-0000-0000-000000000000", "Link cannot be null or empty")]
        [InlineData("Content", null, "00000000-0000-0000-0000-000000000000", "Content cannot be null or empty")]
        public void AddPractical_ConstructorShouldThrowArgumentNullOrEmptyException_WhenInputParametersIsNullOrEmpty(string type, 
            string value, string id, string expectedMessage)
        {
            // Arrange

            // Act & Assert
            Guid topicid = Guid.Parse(id);
            var exception = AssertThrowsArgumentNullOrEmptyException(type, value, topicid);

            /* if (type == "Name")
             {
                 exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
                 new Practical(value, TopicData.TopicId, PracticalData.Link, PracticalData.Content));
             }
             else if(type == "Link")
             {
                 exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
                 new Practical(PracticalData.Name, TopicData.TopicId, value, PracticalData.Content));
             }
             else 
             {
                 exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
                 new Practical(PracticalData.Name, TopicData.TopicId, PracticalData.Link, value));
             }*/



            Assert.Equal(expectedMessage, exception.Message);
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Contains("cannot", exception.Message);
            Assert.EndsWith("empty", exception.Message);
            Assert.EndsWith("Empty", exception.Message, StringComparison.OrdinalIgnoreCase);


        }

        private ArgumentNullOrEmptyException AssertThrowsArgumentNullOrEmptyException(string type, string value, Guid topicId)
        {
            return type switch
            {
                "Name" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                    new Pratical(value, TopicData.TopicId, PracticalData.Link, PracticalData.Content)),
                "Link" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                    new Pratical(PracticalData.Name, TopicData.TopicId, value, PracticalData.Content)),
                "Content" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                    new Pratical(PracticalData.Name, TopicData.TopicId, PracticalData.Link, value)),
                "TopicId" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                new Pratical(PracticalData.Name, topicId, PracticalData.Link, PracticalData.Content)),
                _ => throw new ArgumentNullOrEmptyException("Invalid type specified")
            };
        }
    }
}
