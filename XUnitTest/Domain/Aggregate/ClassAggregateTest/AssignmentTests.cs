using Domain.Aggreagtes.ClassAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.Domain.Aggregate.ClassAggregateTest
{
    public class AssignmentTests
    {
        [Fact]
        public void Constructor_ShouldThrowException_WhenBothLinkAndContentNullOrEmpty()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Assignment(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, 95.0m , "https://example.com", "Contnt base on Assment"));
            Assert.Equal("An assignment must have either a link or content set.", ex.Message);
        }

        [Theory]
        [InlineData("https://example.com", null)]
        [InlineData(null, "Assignment content")]
        public void Constructor_ShouldInitializeProperties_WhenEitherLinkOrContentIsSet(string link, string content)
        {
            var assignment = new Assignment(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, 90.0m, link, content);

            Assert.Equal(link, assignment.Link);
            Assert.Equal(content, assignment.Content);
        }
    }
}
