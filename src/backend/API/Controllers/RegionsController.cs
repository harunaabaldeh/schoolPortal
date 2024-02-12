using API.Dtos;
using API.Entities;
using API.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController : ControllerBase
{
    private readonly IRegionRepository _regionRepository;

    public RegionsController(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
    {
        return Ok(await _regionRepository.GetRegions());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Region>> GetRegion(Guid id)
    {
        return Ok(await _regionRepository.GetRegion(id));
    }

    [HttpPost]
    public async Task<ActionResult<Region>> CreateRegion(RegionDto region)
    {
        await _regionRepository.CreateRegion(region);
        return Ok(region);
    }
}