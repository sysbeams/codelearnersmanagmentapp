using Domain.Aggreagtes.CourseAggregate;
using Domain.Exceptions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestCurriculum;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestExercise;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestPractical;

namespace XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestTopic
{
    public class TopicTest
    {
        private readonly Topic _topic;
        public TopicTest()
        {
            _topic = new Topic(TopicData.Name, CurriculumData.CurriculumId,
                ExerciseData.Name, ExerciseData.Link, ExerciseData.Content);
        }
        [Fact]
        public void AddNewTopicWithNewExercise_ConstructorShouldSetProperties_WhenValidParametersAreProvided()
        {
            //Arrange

            //Act 
           /* Topic newTopicObject = new Topic(TopicData.Name, CurriculumData.CurriculumId,
                ExerciseData.Name, ExerciseData.Link, ExerciseData.Content);*/
            //Assert

            Assert.Equal(TopicData.Name, _topic.Name, ignoreCase: true);
            Assert.StartsWith("Data", _topic.Name);
            Assert.True(_topic.CurriculumId == CurriculumData.CurriculumId);
            Assert.Contains(_topic.Exercises,
                exerciseName => exerciseName.Link == ExerciseData.Link);
            Assert.True(_topic.Exercises.Any(exercise => _topic.Id == exercise.TopicId));

            //check if a topic is having atmost one exercise object when a new topic is created
            Assert.Single(_topic.Exercises);
            Assert.Equal(ExerciseData.Content, _topic.Exercises[0].Content);

        }

        [Theory]
        [InlineData("Name", null, "00000000-0000-0000-0000-000000000000", "Topic name cannot be null or empty")]
        [InlineData("CurriculumId", "", "00000000-0000-0000-0000-000000000000", "Curriculum Id  cannot be empty")]
        [InlineData("ExerciseName", null, "00000000-0000-0000-0000-000000000000", "Exercise name cannot be null or empty")]
        [InlineData("ExerciseLink", null, "00000000-0000-0000-0000-000000000000", "Link cannot be null or empty")]
        [InlineData("ExerciseContent", "", "00000000-0000-0000-0000-000000000000", "Content cannot be null or empty")]


        public void AddNewTopicWithNewExercise_ConstructorShouldThrowArgumentNullOrEmptyException_WhenInputParametersIsNullOrEmpty(string type,
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
            Assert.EndsWith("Empty", exception.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void AddPratical_TopicShouldAddNewPractical_WhenValidParametersAreProvided_PracticalCollectionShouldBeUpdated()
        {
            //Arrange

            //Act 
            _topic.AddPratical(PracticalData.Name, PracticalData.Link, PracticalData.Content);
            //Assert

            Assert.Equal(PracticalData.Name, _topic.Praticals[0].Name, ignoreCase: true);
            Assert.NotNull(_topic.Praticals);
           
        }
        [Fact]
        public void AddExercise_TopicShouldAddNewExercise_WhenValidParametersAreProvided_ExerciseCollectionShouldBeUpdated()
        {
            //Arrange

            //Act 
            _topic.AddExercise(ExerciseData.Name, ExerciseData.Link, ExerciseData.Content);
            //Assert

            Assert.Equal(ExerciseData.Name, _topic.Exercises[0].Name, ignoreCase: true);
            Assert.NotNull(_topic.Exercises);
        }

        [Fact]
        public void RemoveExercise_WhenExerciseObjectIsProvided_ShouldThrowOutOfSpecifiedRangeException_WhenExerciseCountIsLessThanTwo()
        {
            //Arrange
            var exercise = _topic.Exercises.FirstOrDefault(a => a.TopicId == _topic.Id);

            //Act & Assert
            var exception = Assert.Throws<OutOfSpecifiedRangeException>(() =>
                _topic.RemoveExercise(exercise!)
                   );

            Assert.Equal("Exercises cannot be less than 1", exception.Message);
            Assert.IsType<OutOfSpecifiedRangeException>(exception);
            Assert.Contains("Exercises", exception.Message);
            Assert.EndsWith("1", exception.Message);
            Assert.StartsWith("exercises", exception.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void RemoveExercise_ShouldRemoveExerciseObject_WhenExerciseCountIsGreaterThanOrEqualTwo()
        {
            //Arrange
            // Initialize the Topic with at least two exercises
            _topic.AddExercise(ExerciseData.Name, ExerciseData.Link, ExerciseData.Content); 
            var exerciseToRemove = _topic.Exercises[0];
            //Act 
            _topic.RemoveExercise(exerciseToRemove);

            //Assert

            Assert.False(_topic.Exercises.Contains(exerciseToRemove));
           
        }
        [Fact]
        public void RemovePractical_ShouldThrowOutOfSpecifiedRangeException_WhenPracticalCountIsLessThanTwo()
        {
            //Arrange
             _topic.AddPratical(PracticalData.Name, PracticalData.Link, PracticalData.Content);
            var practicalToRemove = _topic.Praticals[0];

            //Act & Assert
            var exception = Assert.Throws<OutOfSpecifiedRangeException>(() =>
                _topic.RemovePratical(practicalToRemove!)
                   );

            Assert.Equal("Praticals cannot be less than 1", exception.Message);
            Assert.IsType<OutOfSpecifiedRangeException>(exception);
            Assert.Contains("Praticals", exception.Message);
            Assert.EndsWith("1", exception.Message);
            Assert.StartsWith("praticals", exception.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void RemoveExercise_ShouldRemovePracticalObject_WhenPracticalCountIsGreaterThanOrEqualTwo()
        {
            //Arrange
            // Initialize the Topic with at least two exercises
            _topic.AddPratical(PracticalData.Name, PracticalData.Link, PracticalData.Content);
            _topic.AddPratical(PracticalData.Name, PracticalData.Link, PracticalData.Content);
            var practicalToRemove1 = _topic.Praticals[0];
            var practicalToRemove2 = _topic.Praticals[1];
            //Act 
            _topic.RemovePratical(practicalToRemove1);

            //Assert

            Assert.False(_topic.Praticals.Contains(practicalToRemove1));

            Assert.DoesNotContain(practicalToRemove1, _topic.Praticals);
            Assert.Contains(practicalToRemove2, _topic.Praticals);
            Assert.Single(_topic.Praticals);
        }
        private ArgumentNullOrEmptyException AssertThrowsArgumentNullOrEmptyException(string type, string value, Guid topicId)
        {
            return type switch
            {
                "Name" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                    new Topic(value, CurriculumData.CurriculumId, ExerciseData.Name, ExerciseData.Link, ExerciseData.Content)),

                "CurriculumId" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                new Topic(TopicData.Name, topicId, ExerciseData.Name, ExerciseData.Link, ExerciseData.Content)),

                "ExerciseName" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                   new Topic(TopicData.Name, CurriculumData.CurriculumId, value, ExerciseData.Link, ExerciseData.Content)),

                "ExerciseLink" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                new Topic(TopicData.Name, CurriculumData.CurriculumId, ExerciseData.Name, value, ExerciseData.Content)),

                "ExerciseContent" => Assert.Throws<ArgumentNullOrEmptyException>(() =>
                new Topic(TopicData.Name, CurriculumData.CurriculumId, ExerciseData.Name, ExerciseData.Link, value)),
                _ => throw new ArgumentNullOrEmptyException("Invalid type specified")
            };
        }
    }
}
