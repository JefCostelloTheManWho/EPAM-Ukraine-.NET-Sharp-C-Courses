using System;
using Xunit;

namespace Enum_Task.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0)]
        [InlineData(13)]
        public void ShowMontsThrowsException(int x)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Program.ShowMonth(x));
        }
    }
}
