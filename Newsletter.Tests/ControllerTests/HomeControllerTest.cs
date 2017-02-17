using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonOfCodSeafood.Controllers;
using SonOfCodSeafood.Models;
using Xunit;
using Moq;

namespace Newsletter.Tests.ControllerTests
{
    public class HomeControllerTest
    {
    
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            var mockDb = new Mock<WebsiteDbContext>();
            HomeController controller = new HomeController(mockDb.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ViewResult_Registered_Test()
        {
            var mockDb = new Mock<WebsiteDbContext>();
            HomeController controller = new HomeController(mockDb.Object);

            var result = controller.Registered();

            Assert.IsType<ViewResult>(result);
        }


        //[Fact]
        //public void Get_ViewResult_Newsletter_Test()
        //{
        //    var mockDb = new Mock<WebsiteDbContext>();
        //    mockDb.Setup(db => db.NewsletterMembers.ToList()).Returns(new List<NewsletterMember> { new NewsletterMember() });
        //    HomeController controller = new HomeController(mockDb.Object);

        //    var result = controller.Newsletter();

        //    Assert.IsType<ViewResult>(result);
        //}
    }
}
