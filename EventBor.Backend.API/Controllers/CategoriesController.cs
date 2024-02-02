using EventBor.Backend.Application.DTOs.Categories;
using EventBor.Backend.Application.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace EventBor.Backend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CategoryForCreationDto dto)
        => Ok(await this._categoryService.AddAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await this._categoryService.RetrieveAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await this._categoryService.RetrieveByIdAsync(id));


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await this._categoryService.RemoveAsync(id));


    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] CategoryForUpdateDto dto)
        => Ok(await this._categoryService.ModifyAsync(id, dto));
}
