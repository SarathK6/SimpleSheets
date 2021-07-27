using SimpleSheets.Data.Impls;
using SimpleSheets.Data.Interface;
using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;

namespace SimpleSheets.Services.Tests
{
    public class AdminRepoTests
    {
        IAdminRepo AdminRepoObj;
        public AdminRepoTests()
        {
            //AdminRepoObj = new AdminRepo(null, null, null, null);

        }

        [Fact]
        void IsProjExists_Should_Return_1_When_Project_Exists()
        {
            // Arrange
            var expected = 1;
            

            // Act
            var actual = 0;// AdminRepoObj.IsProjExists("fake title");

            // Assert
            Assert.Equal(actual, expected);
        }

    }
}
