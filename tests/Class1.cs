using Xunit;
using System;

namespace tests
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
                Assert.Equal(4, Add(2,2));
        }

        [Fact]
        public void FailingTest() 
        {
                Assert.NotEqual(5, Add(2,2));
        }

        int Add(int left, int right) => left + right;
    }
}
