using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Moq;
using WordLab.API.Controllers;
using WordLab.API.Interfaces;

namespace test.unit.tests.API
{
    public class WordLabCotrollerTest
    {
        [Fact]
        public async void InsertWord_WhenWordInserted_ReturnsSuccessWithStatusCode201()
        {
            // Arrange
            var expectedWord = "test";

            // Act
            var wordController = new WordLabController();
            var result = await wordController.InsertionWord(expectedWord);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var statusCodeResult = (StatusCodeResult)result;
            Assert.Equal(201, statusCodeResult.StatusCode);
        }
    }
}