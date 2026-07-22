using SimplCommerce.Infrastructure.Helpers;
using Xunit;

namespace SimplCommerce.Infrastructure.Tests
{
    public class StringHelperTests
    {
        [Fact]
        public void UrlWithOneSpaceShouldBeReplacedWithOneDash()
        {
            var foo = "friendly url".ToUrlFriendly();
            Assert.Equal("friendly-url", foo);
        }

        [Fact]
        public void UrlWithManySpacesShouldBeReplacedWithOneDash()
        {
            var foo = "friendly    url".ToUrlFriendly();
            Assert.Equal("friendly-url", foo);
        }

        [Fact]
        public void UrlWithTwoDashesShouldBeReplacedWithOneDash()
        {
            var foo = "friendly--url".ToUrlFriendly();
            Assert.Equal("friendly-url", foo);
        }

        [Fact]
        public void UrlWithManyDashesShouldBeReplacedWithOneDash()
        {
            var foo = "friendly---url".ToUrlFriendly();
            Assert.Equal("friendly-url", foo);
        }

        [Fact]
        public void LongUrlShouldBeCut()
        {
            const string stringToCut = "01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789qqqqqqqqqqqq";
            Assert.True(stringToCut.Length > 200);
            var foo = stringToCut.ToUrlFriendly();
            Assert.Equal(200, foo.Length);
        }

        [Fact]
        public void UrlWitWhiteSpacesShouldBeGenerated()
        {
            const string stringToCut = " ";
            var foo = stringToCut.ToUrlFriendly();
            Assert.NotEmpty(foo);
        }

        [Fact]
        public void LongUrlWitWhiteSpacesShouldBeGenerated()
        {
            const string stringToCut = "                                                                                                                                                                                                        qqqqqqqqqqqq";
            Assert.True(stringToCut.Length > 200);
            var foo = stringToCut.ToUrlFriendly();
            Assert.NotEmpty(foo);
        }
    }
}
