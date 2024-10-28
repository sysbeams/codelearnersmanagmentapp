
using Domain.Aggreagtes.CourseAggregate.CourseAggregateTest.UnitTestTopic;
using Xunit;

namespace Domain.Aggreagtes.CourseAggregate.CourseAggregateTest.UnitTestPractical
{
    public class PracticalTest
    {
        [Fact]
        public void AddPractical_ConstructorShouldSetPropertyValue_WithInputParameters()
        {
            //Arrange
            Pratical praticalObject = new Pratical(PracticalData.Name, TopicData.TopicId, PracticalData.Link, PracticalData.Content);

            //Assert

            Assert.Equal(PracticalData.Name, praticalObject.Name);
        }
    }
}
