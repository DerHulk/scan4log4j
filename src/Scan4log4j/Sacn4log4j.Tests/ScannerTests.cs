using Scan4log4j;
using Xunit;

namespace Sacn4log4j.Tests
{
    public class ScannerTests
    {
        private Scanner Target { get; }

        public ScannerTests()
        {
            this.Target = new Scanner();
        }

        [Fact(DisplayName = "Checks that IsVulnerable is true if the path ends with 'jndilookup.class'.")]
        public void Analyse01()
        {
            //arrange
            var paths = new[] { "test/jndilookup.class",
                                "test/core/logevent.class",
                                "test/core/appender.class",
                                "test/core/filter.class",
                                "test/core/layout.class",
                                "test/core/loggercontext.class"
                                };

            //act
            var result = this.Target.Analyse(paths);

            //assert
            Assert.True(result.IsVulnerable);
        }
    }
}