using Domain.Aggreagtes.CourseAggregate;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestCourse;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestExercise;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestPractical;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestTopic;

namespace XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestCurriculum
{
    public class CurriculumTest
    {
        private readonly Curriculum _curriculum;
       
        public CurriculumTest()
        {
            _curriculum =  new Curriculum(CourseData.CourseId, TopicData.Name,
                 ExerciseData.Name, ExerciseData.Link, ExerciseData.Content);
        }
        [Fact]
        public void AddNewCurriculumWithNewTopic_ConstructorShouldSetProperties_WhenValidParametersAreProvided()
        {
            
            //Arrange

            //Act 
            
            //Assert

            Assert.Equal(TopicData.Name, _curriculum.Topics[0].Name, ignoreCase: true);
            Assert.Equal(CourseData.CourseId, _curriculum.CourseId);
           
        }

        [Theory]
        [InlineData("CourseId", null, "00000000-0000-0000-0000-000000000000", "Course ID is not a match")]
        [InlineData("TopicName", "", "00000000-0000-0000-0000-000000000000", "Topic name cannot be null or empty")]
        [InlineData("ExerciseName", null, "00000000-0000-0000-0000-000000000000", "Exercise name cannot be null or empty")]
        [InlineData("ExerciseLink", null, "00000000-0000-0000-0000-000000000000", "Link cannot be null or empty")]
        [InlineData("ExerciseContent", "", "00000000-0000-0000-0000-000000000000", "Content cannot be null or empty")]
        public void AddNewCurriculumWithNewTopic_ConstructorShouldThrowArgumentNullOrEmptyException_WhenInputParameterIsNullOrEmpty(string type,
            string value, string id, string expectedMessage)
        {

            //Arrange
            
            //Act 
            Guid courseid = Guid.Parse(id);
            var exception = AssertThrowsArgumentNullOrEmptyException(type, value, courseid);
            //Asset

            Assert.Equal(expectedMessage, exception.Message);
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Contains("not", exception.Message);
        }

        [Fact]
        public void AddTopic_CurriculumShouldAddNewTopic_WhenValidParametersAreProvided()
        {

            //Arrange

            //Act 
            _curriculum.AddTopic(TopicData.Name, ExerciseData.Name, ExerciseData.Link, ExerciseData.Content);
            //Assert

            Assert.Equal(TopicData.Name, _curriculum.Topics[0].Name);  
        }

        [Fact]
        public void ValidateTopic_CurriculumShouldValidateTopicObject_WhenObjectIsNotNull()
        {

            //Arrange
            Topic topic = new Topic(TopicData.Name, _curriculum.Id, 
                ExerciseData.Name, ExerciseData.Link, ExerciseData.Content);
            //Act 
            _curriculum.ValidateTopic(topic);
            //Assert

            Assert.Contains(topic, _curriculum.Topics);
            Assert.Contains(_curriculum.Topics,
                topicObject => topicObject == topic);
            Assert.True(_curriculum.Topics.Any(t => TopicData.Name == t.Name));

        }
        [Fact]
        public void ValidateTopic_ShouldThrowArgumentNullOrEmptyException_WhenObjectIsNull()
        {

            //Arrange

            //Act && Assert
            var exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
            _curriculum.ValidateTopic(null));

            Assert.Equal("Topic cannot be null", exception.Message);
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Contains("cannot", exception.Message);
            Assert.EndsWith("null", exception.Message);
            Assert.StartsWith("Topic", exception.Message);
        }

        [Fact]
        public void ValidateTopic_ShouldThrowArgumentNullOrEmptyException_WhenCurriculumIdIsNotMatch()
        {

            //Arrange
            Topic topic = new Topic(TopicData.Name, CurriculumData.CurriculumId,
                ExerciseData.Name, ExerciseData.Link, ExerciseData.Content);
            //Act && Assert
            var exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
            _curriculum.ValidateTopic(topic));

            Assert.Equal("Topic Curriculum Id is not a match", exception.Message);
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Contains("id", exception.Message, StringComparison.CurrentCultureIgnoreCase);
            Assert.EndsWith("match", exception.Message);
            Assert.StartsWith("Topic", exception.Message);
        }

        [Fact]
        public void RemoveTopic_WhenExerciseObjectIsProvided_ShouldThrowOutOfSpecifiedRangeException_WhenExerciseCountIsLessThanTwo()
        {
            //Arrange
            var topic = _curriculum.Topics[0];

            //Act & Assert
            var exception = Assert.Throws<OutOfSpecifiedRangeException>(() =>
                _curriculum.RemoveTopic(topic!)
                   );

            Assert.Equal("Topic cannot be less than 1", exception.Message);
            Assert.IsType<OutOfSpecifiedRangeException>(exception);
            Assert.Contains("Topic", exception.Message);
            Assert.EndsWith("1", exception.Message);
            Assert.StartsWith("topic", exception.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void RemoveTopic_ShouldRemoveTopicObject_WhenTopicCountIsGreaterThanOrEqualTwo()
        {
            //Arrange
            // Initialize the Curriculum with at least two exercises
            _curriculum.AddTopic(TopicData.Name, ExerciseData.Name, ExerciseData.Link, ExerciseData.Content);
            var topicToRemove = _curriculum.Topics[0];

            //Act 
            _curriculum.RemoveTopic(topicToRemove);

            //Assert

            Assert.False(_curriculum.Topics.Contains(topicToRemove));

            Assert.DoesNotContain(topicToRemove, _curriculum.Topics);
            Assert.Single(_curriculum.Topics);

        }
        private ArgumentNullOrEmptyException AssertThrowsArgumentNullOrEmptyException(string type, string value, Guid courseid)
        {
            return type switch
            {
                "CourseId" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                    new Curriculum(courseid, TopicData.Name, ExerciseData.Name, ExerciseData.Link, ExerciseData.Content)),

                "TopicName" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                new Curriculum(CourseData.CourseId, value, ExerciseData.Name, ExerciseData.Link, ExerciseData.Content)),

                "ExerciseName" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                   new Curriculum(CourseData.CourseId,TopicData.Name, value, ExerciseData.Link, ExerciseData.Content)),

                "ExerciseLink" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                new Curriculum(CourseData.CourseId,TopicData.Name, ExerciseData.Name, value, ExerciseData.Content)),

                "ExerciseContent" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                new Curriculum(CourseData.CourseId,TopicData.Name, ExerciseData.Name, ExerciseData.Link, value)),

                _ => throw new ArgumentNullOrEmptyException("Invalid type specified")
            };
        }
    }
}
