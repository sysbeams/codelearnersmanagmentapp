using Domain.Aggreagtes.CourseAggregate;
using Domain.Enums;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestCourseBatch;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestCurriculum;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestExercise;
using XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestTopic;

namespace XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestCourse
{
    public class CourseTest
    {
        private readonly Course _course;
        private readonly CourseBatch _courseBatch;

        public CourseTest()
        {
            _courseBatch = new CourseBatch(CourseBatchData.BatchNo, CourseBatchData.DateOpened, CourseBatchData.DateClosed,
               CourseBatchData.Capacity,
                new List<CourseMode>
                {
                     CourseMode.Physical,
                     CourseMode.Hybrid,
                     CourseMode.Virtual,
                });

            
            _course = new Course(CourseData.Name, _courseBatch, TopicData.Name, ExerciseData.Name,
           ExerciseData.Link, ExerciseData.Content);
        }
        [Fact]
        public void AddNewCourseWithCourseBatchAndCurriculum_ConstructorShouldSetProperties_WhenValidParametersAreProvided()
        {

            //Arrange
            
            //Act 

            //Act & Assert

            Assert.Equal(CourseData.Name, _course.Name, ignoreCase: true);
            Assert.Contains(_courseBatch, _course.Batches);
            Assert.Equal(TopicData.Name , _course.Curriculum.Topics[0].Name);
            Assert.Equal(_courseBatch.CourseModes , _course.Batches[0].CourseModes);
        }

        [Fact]
        public void AddNewCourseWithCourseBatchAndCurriculum_ShouldThrowArgumentNullOrEmptyException_WhenNameParameterIsNull()
        {

            //Arrange
            string courseName = null;
            //Act & Assert

            var exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
                 new Course(courseName, _courseBatch, TopicData.Name, ExerciseData.Name,
           ExerciseData.Link, ExerciseData.Content));


            Assert.Equal("Course name cannot be null or empty", exception.Message);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Contains("cannot", exception.Message);
            Assert.EndsWith("empty", exception.Message);
            Assert.StartsWith("Course", exception.Message, StringComparison.OrdinalIgnoreCase);

        }
        [Fact]

        public void AddBatch_ShouldAddNewBatch_CourseBatchListBeUpdatedWhenBatchIsNotNull()
        {

            //Arrange

            //Act 
            _course.AddBatch(_courseBatch);
            //Assert

            Assert.Equal(CourseBatchData.BatchNo, _course.Batches[0].BatchNo, ignoreCase: true);
            Assert.Contains(_courseBatch, _course.Batches);
            Assert.Equal(TopicData.Name, _course.Curriculum.Topics[0].Name);
            Assert.Equal(_courseBatch.CourseModes, _course.Batches[1].CourseModes);

        }

        [Fact]
        public void AddBatch_ShouldThrowArgumentNullOrEmptyException_WhenBatchIsNull()
        {

            //Arrange

            //Act & Assert
            
            var exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
                 _course.AddBatch(null));
                   

            Assert.Equal("Batch cannot be null", exception.Message);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Contains("cannot", exception.Message);
            Assert.EndsWith("null", exception.Message);
            Assert.StartsWith("Batch", exception.Message, StringComparison.OrdinalIgnoreCase);

        }

        [Fact]
        public void AddAndValidateCurriculum_ShouldThrowArgumentNullOrEmptyException_WhenAttemptingToAddNewCurriculum()
        {

            //Arrange

            //Act &Assert

            var exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
                 _course.AddAndValidateCurriculum(TopicData.Name, ExerciseData.Name, ExerciseData.Link, 
                 ExerciseData.Content));


            Assert.Equal("Course belongs to a Curriculum", exception.Message);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Contains("belongs", exception.Message);
            Assert.EndsWith("Curriculum", exception.Message);
            Assert.StartsWith("Course", exception.Message, StringComparison.OrdinalIgnoreCase);

        }


    }
}
