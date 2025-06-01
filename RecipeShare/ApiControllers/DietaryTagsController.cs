using ClassLibrary.API;
using ClassLibrary.Data;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeShare.Helpers;

namespace RecipeShare.Api.Controllers
{
    [Area("API")]
    [Route("api/[controller]")]
    [ApiController]
    public class DietaryTagsController : ControllerBase
    {
        private readonly DietaryTagRepository _dietaryTagRepository;

        public DietaryTagsController(ApplicationDbContext context, DietaryTagRepository dietaryTagRepository)
        {
            _dietaryTagRepository = dietaryTagRepository ?? throw new ArgumentNullException(nameof(dietaryTagRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _dietaryTagRepository.GetAsQueryable().ToListAsync();

            if (tags == null || tags.Count == 0)
            {
                return ApiResponseHelper.NotFoundResponse("No dietary tags found.");
            }

            return ApiResponseHelper.OkResponse("Dietary tags retrieved successfully.", tags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tag = await _dietaryTagRepository.GetById(id);

            if (tag == null)
            {
                return ApiResponseHelper.NotFoundResponse("Dietary tag not found.");
            }

            return ApiResponseHelper.OkResponse("Dietary tag found.", tag);
        }
    }
}
