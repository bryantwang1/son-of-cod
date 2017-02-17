using SonOfCodSeafood.Models;
using Xunit;

namespace SonOfCod.Tests
{
    public class ItemTest
    {
        [Fact]
        public void GetEmailTest()
        {
            var member = new NewsletterMember();

            member.Email = "moocow@gmail.com";
            var result = member.Email;

            Assert.Equal("moocow@gmail.com", result);
        }
    }
}