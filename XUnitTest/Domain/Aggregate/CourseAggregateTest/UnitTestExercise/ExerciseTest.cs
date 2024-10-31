using Domain.Aggreagtes.CourseAggregate;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestTopic;

namespace XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestExercise
{
    public class ExerciseTest
    {
        [Fact]
        public void Constructor_ShouldSetProperties_WhenValidParametersAreProvided()
        {
            //Arrange
            //Act
            Exercise exerciseObject = new Exercise(ExerciseData.Name, TopicData.TopicId, ExerciseData.Link, ExerciseData.Content);

            //Assert

            Assert.Equal(ExerciseData.Name, exerciseObject.Name);
            Assert.Equal(TopicData.TopicId, exerciseObject.TopicId);
            Assert.Equal(ExerciseData.Link, exerciseObject.Link);
            Assert.Equal(ExerciseData.Content, exerciseObject.Content);
        }

        [Theory]
        [InlineData("Name", null, "00000000-0000-0000-0000-000000000000", "Exercise name cannot be null or empty")]
        [InlineData("TopicId", "", "00000000-0000-0000-0000-000000000000", "Topic Id cannot be empty")]
        [InlineData("Link", "", "00000000-0000-0000-0000-000000000000", "Link cannot be null or empty")]
        [InlineData("Content", null, "00000000-0000-0000-0000-000000000000", "Content cannot be null or empty")]
        public void AddExercise_ConstructorShouldThrowArgumentNullOrEmptyException_WhenInputParametersIsNullOrEmpty(string type,
            string value, string id, string expectedMessage)
        {
            // Arrange

            // Act & Assert
            Guid topicid = Guid.Parse(id);
            var exception = AssertThrowsArgumentNullOrEmptyException(type, value, topicid);


            Assert.Equal(expectedMessage, exception.Message);
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Contains("cannot", exception.Message);
            Assert.EndsWith("empty", exception.Message);

        }

        private ArgumentNullOrEmptyException AssertThrowsArgumentNullOrEmptyException(string type, string value, Guid topicId)
        {
            return type switch
            {
                "Name" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                    new Exercise(value, TopicData.TopicId, ExerciseData.Link, ExerciseData.Content)),
                "Link" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                    new Exercise(ExerciseData.Name, TopicData.TopicId, value, ExerciseData.Content)),
                "Content" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                    new Exercise(ExerciseData.Name, TopicData.TopicId, ExerciseData.Link, value)),
                "TopicId" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                new Exercise(ExerciseData.Name, topicId, ExerciseData.Link, ExerciseData.Content)),
                _ => throw new ArgumentNullOrEmptyException("Invalid type specified")
            };
        }
    }
}
