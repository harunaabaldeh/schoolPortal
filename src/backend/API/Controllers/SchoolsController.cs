using API.Dtos;
using API.Entities;
using API.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolsController : ControllerBase
{
    private readonly ISchoolRepository _schoolRepository;
    public SchoolsController(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<School>>> GetSchools()
    {
        return Ok(await _schoolRepository.GetSchools());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<School>> GetSchool(Guid id)
    {
        return Ok(await _schoolRepository.GetSchoolById(id));
    }

    [HttpPost]
    public async Task<ActionResult<SchoolDto>> CreateSchool(SchoolDto schoolDto)
    {
        if (ModelState.IsValid is false)
            return BadRequest("Invalid data");

        await _schoolRepository.CreateSchoolAsync(schoolDto);
        return Ok(schoolDto);
    }
}