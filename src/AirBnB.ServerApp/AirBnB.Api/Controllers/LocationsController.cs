using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirBnB.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController(IMapper mapper) : ControllerBase
{
    [HttpGet("countries")]
    public async Task<IActionResult> GetCountries([FromQuery] CountryFilter countryFilter, [FromServices] ICountryService countryService)
    {
        var result = await countryService.GetAsync(countryFilter);
        return result.Any() ? Ok(mapper.Map<IEnumerable<CountryDto>>(result)) : NoContent();
    }

    [HttpGet("cities")]
    public async ValueTask<IActionResult> GetCities([FromQuery] CityFilter cityFilter, [FromServices] ICityService cityService)
    {
        var result = await cityService.GetAsync(cityFilter);
        return result.Any() ? Ok(mapper.Map<IEnumerable<CityDto>>(result)) : NoContent();
    }
}