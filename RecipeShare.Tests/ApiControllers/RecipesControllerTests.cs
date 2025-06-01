using ClassLibrary.DTOs;
using ClassLibrary.Models;
using ClassLibrary.Operations;
using ClassLibrary.Repositories.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipeShare.ApiControllers;
using RecipeShare.Helpers;
using RecipeShare.Tests.Helpers;

namespace RecipeShare.Tests.ApiControllers
{
    public class RecipesControllerTests
    {
        private readonly Mock<IRecipeRepository> _mockRepo;
        private readonly RecipesController _controller;

        public RecipesControllerTests()
        {
            _mockRepo = new Mock<IRecipeRepository>();
            _controller = new RecipesController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkWithRecipes()
        {
            var recipes = new List<Recipe> { new Recipe { ID = Guid.NewGuid(), Title = "Test" } };
            var asyncRecipes = new TestAsyncEnumerable<Recipe>(recipes);
            _mockRepo.Setup(r => r.GetAsQueryable()).Returns(asyncRecipes);

            var result = await _controller.GetAll();

            result.Should().BeOfType<OkObjectResult>();
            var ok = result as OkObjectResult;
            var response = ok!.Value as ApiResponse;

            response!.Status.Should().Be("success");
            response.Message.Should().Be("Fetched recipes");
            response.Data.Should().BeAssignableTo<IEnumerable<Recipe>>();
        }

        [Fact]
        public async Task GetById_RecipeExists_ReturnsOk()
        {
            var id = Guid.NewGuid();
            var recipe = new Recipe { ID = id, Title = "Test" };
            _mockRepo.Setup(r => r.GetById(id)).ReturnsAsync(recipe);

            var result = await _controller.GetById(id);

            var ok = result as OkObjectResult;
            var response = ok!.Value as ApiResponse;

            response!.Status.Should().Be("success");
            response.Message.Should().Be("Recipe found");
            response.Data.Should().BeEquivalentTo(recipe);
        }

        [Fact]
        public async Task GetById_RecipeDoesNotExist_ReturnsNotFound()
        {
            var id = Guid.NewGuid();
            _mockRepo.Setup(r => r.GetById(id)).ReturnsAsync((Recipe)null!);

            var result = await _controller.GetById(id);

            result.Should().BeOfType<NotFoundObjectResult>();
            var notFound = result as NotFoundObjectResult;
            var response = notFound!.Value as ApiResponse;

            response!.Status.Should().Be("error");
            response.Message.Should().Be("Recipe not found");
            response.Data.Should().BeNull();
        }

        [Fact]
        public async Task Create_ValidDto_ReturnsCreated()
        {
            var dto = new RecipeDto { Title = "New" };
            _mockRepo.Setup(r => r.Create(It.IsAny<Recipe>()))
                     .ReturnsAsync(OperationResult.SuccessResult("Created"));

            var result = await _controller.Create(dto);

            result.Should().BeOfType<CreatedResult>();
            var created = result as CreatedResult;
            var response = created!.Value as ApiResponse;

            response!.Status.Should().Be("success");
            response.Message.Should().Be("Recipe created");
            response.Data.Should().BeAssignableTo<RecipeDto>();
        }

        [Fact]
        public async Task Update_IdIsEmpty_ReturnsBadRequest()
        {
            var dto = new RecipeDto { ID = Guid.Empty, Title = "Invalid" };

            var result = await _controller.Update(dto);

            result.Should().BeOfType<BadRequestObjectResult>();
            var badRequest = result as BadRequestObjectResult;
            var response = badRequest!.Value as ApiResponse;

            response!.Status.Should().Be("error");
            response.Message.Should().Be("ID cannot be null");
        }

        [Fact]
        public async Task Update_RecipeNotFound_ReturnsNotFound()
        {
            var id = Guid.NewGuid();
            var dto = new RecipeDto { ID = id, Title = "Update" };

            _mockRepo.Setup(r => r.GetById(id)).ReturnsAsync((Recipe)null!);

            var result = await _controller.Update(dto);

            result.Should().BeOfType<NotFoundObjectResult>();
            var notFound = result as NotFoundObjectResult;
            var response = notFound!.Value as ApiResponse;

            response!.Status.Should().Be("error");
            response.Message.Should().Be("Recipe not found");
        }

        [Fact]
        public async Task Update_ValidDto_UpdatesAndReturnsOk()
        {
            var id = Guid.NewGuid();
            var existing = new Recipe { ID = id, Title = "Old" };
            var dto = new RecipeDto { ID = id, Title = "Updated" };

            _mockRepo.Setup(r => r.GetById(id)).ReturnsAsync(existing);
            _mockRepo.Setup(r => r.Update(It.IsAny<Recipe>()))
                     .ReturnsAsync(OperationResult.SuccessResult("Updated"));

            var result = await _controller.Update(dto);

            result.Should().BeOfType<OkObjectResult>();
            var ok = result as OkObjectResult;
            var response = ok!.Value as ApiResponse;

            response!.Status.Should().Be("success");
            response.Message.Should().Be("Recipe updated");
            response.Data.Should().BeAssignableTo<RecipeDto>();
        }

        [Fact]
        public async Task Delete_ValidId_ReturnsOk()
        {
            var id = Guid.NewGuid();

            _mockRepo.Setup(r => r.Delete(id))
                     .ReturnsAsync(OperationResult.SuccessResult("Deleted"));

            var result = await _controller.Delete(id);

            result.Should().BeOfType<OkObjectResult>();
            var ok = result as OkObjectResult;
            var response = ok!.Value as ApiResponse;

            response!.Status.Should().Be("success");
            response.Message.Should().Be("Recipe deleted");
            (response.Data as object[]).Should().BeEmpty();
        }
    }
}
