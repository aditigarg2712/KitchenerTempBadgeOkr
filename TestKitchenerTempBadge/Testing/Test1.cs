using Business.Layer.Services;
using Data.Access.Layer.Models;
using Data.Access.Layer.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace TestKitchenerTempBadge.Testing
{
    public class Test1
    {
        private readonly Mock<IGenricRepository> repoTest;
        public Test1()
        {
            repoTest = new Mock<IGenricRepository>();
        }
        public List<Gaurd> getGuardData()
        {
            List<Gaurd> guards = new List<Gaurd>
            {
                new Gaurd
                {
                    Id=1,
                    FirstName = "Aditi",
                    LastName = "Garg",
                    EmpCode = 1,
                    SignIn = DateTime.Now,
                    TempBadge = "656987",
                    SignOut= DateTime.Now,
                }
            };
            return guards;
        }

        [Fact]
        public void SignInBadge_STest()
        {
            var f = getGuardData();
            repoTest.Setup(x => x.SignInBadge(f[0].FirstName, f[0].LastName, f[0].EmpCode)).Returns(f);
            var test = new GuardService(repoTest.Object);
            var result = test.SignInBadge(f[0].FirstName, f[0].LastName, f[0].EmpCode);
            Assert.NotNull(result);
        }

        [Fact]
        public void SignInBadge_FTest()
        {
            var f = getGuardData();
            repoTest.Setup(x => x.SignInBadge(f[0].FirstName, f[0].LastName, f[0].EmpCode)).Returns(f);
            var test = new GuardService(repoTest.Object);
            var result = test.SignInBadge(null, f[0].LastName, 2);
            Assert.Null(result);
        }
        [Fact]
        public void SignOutBadge_Test()
        {
            var f = getGuardData();
            repoTest.Setup(x => x.SignOutBadge(f[0].Id)).Returns(f);
            var test = new GuardService(repoTest.Object);
            var result = test.SignOutBadge(0);
            Assert.Null(result);
        }
        [Fact]
        public void SignOutPage_Test()
        {
            var f = getGuardData();
            repoTest.Setup(x => x.SignOutPage(f[0].TempBadge)).Returns(f);
            var test = new GuardService(repoTest.Object);
            var result = test.SignOutPage(null);
            Assert.Null(result);

        }
        [Fact]
        public void SignOutPage_Test1()
        {
            var f = getGuardData();
            repoTest.Setup(x => x.SignOutPage(f[0].TempBadge)).Returns(f);
            var test = new GuardService(repoTest.Object);
            var result = test.SignOutPage("");
            Assert.Null(result);

        }

    }
}

