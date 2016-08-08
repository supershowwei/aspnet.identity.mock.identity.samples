using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;
using AspNetIdentityMockIdentitySamples.Controllers;
using AspNetIdentityMockIdentitySamples.ViewModels;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AspNetIdentityMockIdentitySamples.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Test_Who_user_role_is_Admin_expect_receive_user_roles_contain_Admin()
        {
            // Arrange
            var controller = new HomeController();
            var claimsIdentity = Substitute.For<ClaimsIdentity>();
            var controllerContext = Substitute.For<ControllerContext>();

            // 偽造身份
            claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)
                          .Returns(new Claim(ClaimTypes.NameIdentifier, "johnny"));

            claimsIdentity.Name.Returns("主廚");

            claimsIdentity.FindAll(ClaimTypes.Role)
                          .Returns(new List<Claim>()
                          {
                              new Claim(ClaimTypes.Role, "Admin")
                          });

            controllerContext.HttpContext.User.Identity.Returns(claimsIdentity);

            controller.ControllerContext = controllerContext;

            // Act
            var actual = controller.Who().Data as UserViewModel;

            // Assert
            actual.Id.Should().Be("johnny");
            actual.Name.Should().Be("主廚");
            actual.Roles.Should().Contain("Admin");
        }

        [TestMethod]
        public void Test_Who_user_role_is_User_expect_receive_user_roles_contain_User()
        {
            // Arrange
            var controller = new HomeController();
            var claimsIdentity = Substitute.For<ClaimsIdentity>();
            var controllerContext = Substitute.For<ControllerContext>();

            // 偽造身份
            claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)
                          .Returns(new Claim(ClaimTypes.NameIdentifier, "mary"));

            claimsIdentity.Name.Returns("一般使用者");

            claimsIdentity.FindAll(ClaimTypes.Role)
                          .Returns(new List<Claim>()
                          {
                              new Claim(ClaimTypes.Role, "User")
                          });

            controllerContext.HttpContext.User.Identity.Returns(claimsIdentity);

            controller.ControllerContext = controllerContext;

            // Act
            var actual = controller.Who().Data as UserViewModel;

            // Assert
            actual.Id.Should().Be("mary");
            actual.Name.Should().Be("一般使用者");
            actual.Roles.Should().Contain("User");
        }
    }
}