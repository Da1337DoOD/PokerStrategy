using System;
using Xunit;

namespace PokerStrategy.Services.Reply.Tests
{
    public class ForumReplies
    {
        [Fact]
        public void Test1()
        {
            var a = 2;
            var b = 3;

            var sum = a + b;

            Assert.Equal(5, sum);
        }
    }
}
