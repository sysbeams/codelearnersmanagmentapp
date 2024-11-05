using Domain.Aggreagtes.ClassAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.Domain.Aggregate.ClassAggregateTest
{
    public class AssignmentSubmissionTests
    {
        [Fact]
        public void Constructor_ShouldThrowException_WhenBothLinkAndContentNullOrEmpty()
        {
            var ex = Assert.Throws<ArgumentException>(() => new AssignmentSubmission(Guid.NewGuid(), Guid.NewGuid(), 95.5m));
            Assert.Equal("A submission must have either a link or content set.", ex.Message);
        }

        [Theory]
        [InlineData("https://example.com", null)]
        [InlineData(null, "Submitted content")]
        public void Constructor_ShouldInitializeProperties_WhenEitherLinkOrContentIsSet(string link, string content)
        {
            var submission = new AssignmentSubmission(Guid.NewGuid(), Guid.NewGuid(), 85.0m, link, content);

            Assert.Equal(link, submission.Link);
            Assert.Equal(content, submission.Content);
        }
    }
}
