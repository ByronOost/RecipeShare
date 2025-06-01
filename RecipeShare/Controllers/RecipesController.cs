using AutoMapper;
using ClassLibrary.API;
using ClassLibrary.Models;
using ClassLibrary.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using RecipeShare.Helpers;
using RecipeShare.RequestModels;
using RecipeShare.ViewModels;
using System.Text;
using System.Text.Json;

namespace RecipeShare.Controllers
{
    public class RecipesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public RecipesController(HttpClient httpClient, IConfiguration configuration, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
            _apiBaseUrl = configuration["ApiBaseUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/recipes");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<Recipe>>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            RecipeIndexViewModel viewModel = new()
            {
                Recipes = _mapper.Map<List<RecipeViewModel>>(apiResponse?.Data)
            };

            var tagResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/dietarytags");
            var tagJson = await tagResponse.Content.ReadAsStringAsync();
            var tagApiResponse = JsonSerializer.Deserialize<ApiResponse<List<DietaryTag>>>(tagJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            viewModel.DietaryTagsList = tagApiResponse?.Data?.Select(dt => new SelectListItem
            {
                Value = dt.ID.ToString(),
                Text = dt.Name
            }).ToList() ?? new List<SelectListItem>();

            return View(viewModel);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/recipes/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<Recipe>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            RecipeDetailsViewModel? viewModel = _mapper.Map<RecipeDetailsViewModel>(apiResponse?.Data);

            for (int i = 0; i < apiResponse?.Data.RecipeDietaryTags.Count; i++)
            {
                viewModel.DietaryTags!.Add(apiResponse?.Data.RecipeDietaryTags[i].DietaryTag.Name!);
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/dietarytags");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<DietaryTag>>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            RecipeCreateViewModel viewModel = new()
            {
                DietaryTagsList = apiResponse?.Data?.Select(dt => new SelectListItem
                {
                    Value = dt.ID.ToString(),
                    Text = dt.Name
                }).ToList() ?? new List<SelectListItem>()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        public async Task<IActionResult> Create(RecipeCreateRequestModel recipe)
        {
            if (recipe.Image != null)
            {
                DocumentViewModel document = DocumentHelper.SaveDocumentToMedia(_hostingEnvironment, recipe.Image, $"{recipe.Title}-" + Guid.NewGuid().ToString(), "Images");

                recipe.ImageUrl = document.Document;
            }

            var content = new StringContent(JsonSerializer.Serialize(recipe), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_apiBaseUrl}/recipes", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            await AddApiErrorsToModelState(response);

            var tagResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/dietarytags");
            var tagJson = await tagResponse.Content.ReadAsStringAsync();
            var tagApiResponse = JsonSerializer.Deserialize<ApiResponse<List<DietaryTag>>>(tagJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            RecipeCreateViewModel viewModel = new()
            {
                DietaryTagsList = tagApiResponse?.Data?.Select(dt => new SelectListItem
                {
                    Value = dt.ID.ToString(),
                    Text = dt.Name
                }).ToList() ?? new List<SelectListItem>()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var recipeResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/recipes/{id}");
            if (!recipeResponse.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var recipeJson = await recipeResponse.Content.ReadAsStringAsync();
            var recipeApiResponse = JsonSerializer.Deserialize<ApiResponse<Recipe>>(recipeJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (recipeApiResponse?.Data == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<RecipeEditViewModel>(recipeApiResponse.Data);

            var dietaryTagsResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/dietarytags");
            if (!dietaryTagsResponse.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var dietaryTagsJson = await dietaryTagsResponse.Content.ReadAsStringAsync();
            var dietaryTagsApiResponse = JsonSerializer.Deserialize<ApiResponse<List<DietaryTag>>>(dietaryTagsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var allDietaryTags = dietaryTagsApiResponse?.Data ?? new List<DietaryTag>();
            var selectedTagIds = recipeApiResponse.Data.RecipeDietaryTags.Select(rdt => rdt.DietaryTagID).ToList();

            viewModel.DietaryTagsList = allDietaryTags.Select(dt => new SelectListItem
            {
                Value = dt.ID.ToString(),
                Text = dt.Name,
                Selected = selectedTagIds.Contains(dt.ID)
            }).ToList();

            viewModel.DietaryTags = selectedTagIds;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        public async Task<IActionResult> Edit(RecipeEditRequestModel recipe)
        {
            if (recipe.Image != null)
            {
                DocumentViewModel document = DocumentHelper.SaveDocumentToMedia(_hostingEnvironment, recipe.Image, $"{recipe.Title}-" + Guid.NewGuid().ToString(), "Images");

                recipe.ImageUrl = document.Document;
            }

            var deleteResponse = await _httpClient.DeleteAsync($"{_apiBaseUrl}/recipes/{recipe.ID}/dietarytags");
            if (!deleteResponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Failed to remove existing dietary tags.");
            }

            var content = new StringContent(JsonSerializer.Serialize(recipe), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_apiBaseUrl}/recipes/{recipe.ID}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            await AddApiErrorsToModelState(response);

            var recipeResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/recipes/{recipe.ID}");
            var recipeJson = await recipeResponse.Content.ReadAsStringAsync();
            var recipeApiResponse = JsonSerializer.Deserialize<ApiResponse<Recipe>>(recipeJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var dietaryTagsResponse = await _httpClient.GetAsync($"{_apiBaseUrl}/dietarytags");
            var dietaryTagsJson = await dietaryTagsResponse.Content.ReadAsStringAsync();
            var dietaryTagsApiResponse = JsonSerializer.Deserialize<ApiResponse<List<DietaryTag>>>(dietaryTagsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var viewModel = _mapper.Map<RecipeEditViewModel>(recipeApiResponse?.Data);
            var allDietaryTags = dietaryTagsApiResponse?.Data ?? new List<DietaryTag>();
            var selectedTagIds = recipeApiResponse?.Data?.RecipeDietaryTags.Select(rdt => rdt.DietaryTagID).ToList() ?? new List<Guid>();

            viewModel.DietaryTagsList = allDietaryTags.Select(dt => new SelectListItem
            {
                Value = dt.ID.ToString(),
                Text = dt.Name,
                Selected = selectedTagIds.Contains(dt.ID)
            }).ToList();

            viewModel.DietaryTags = selectedTagIds;

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/recipes/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? term, string? dietaryTag)
        {
            var queryParams = new List<string>
            {
                $"term={term}",
                $"dietaryTag={dietaryTag}"
            };

            string query = string.Join("&", queryParams);
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/recipes/search?{query}");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<Recipe>>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var rootUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";

            RecipeIndexViewModel viewModel = new()
            {
                Recipes = _mapper.Map<List<RecipeViewModel>>(apiResponse?.Data)
            };

            return PartialView("~/Views/Recipes/_Partials/IndexData.cshtml", viewModel);
        }


        private async Task AddApiErrorsToModelState(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (apiResponse?.Errors != null)
            {
                foreach (var error in apiResponse.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
        }
    }
}
