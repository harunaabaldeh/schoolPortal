using API.Data;
using API.Dtos;
using API.Entities;
using API.IRepositories;
using API.StoreChanges;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Repositories;
public class SchoolRepository : ISchoolRepository
{
    private readonly SchoolPortalContext _schoolPortalContext;
    private readonly IStore _store;
    public SchoolRepository(SchoolPortalContext schoolPortalContext, IStore store)
    {
        _schoolPortalContext = schoolPortalContext;
        _store = store;
    }

    public async Task CreateSchoolAsync(SchoolDto schoolDto)
    {
        var school = new School
        {
            SchoolName = schoolDto.SchoolName,
            SchoolCode = schoolDto.SchoolCode,
            PrincipleName = schoolDto.PrincipleName,
            RegionId = schoolDto.RegionId
        };

        await _schoolPortalContext.Schools.AddAsync(school);

        await _store.SaveChangesAsync();
    }

    public async Task<School> GetSchoolById(Guid id)
    {
        var school = await _schoolPortalContext.Schools.FirstOrDefaultAsync(s => s.Id == id);

        if (school is null)
            throw new ArgumentNullException($"School with the Id {id} was not found");

        return school;
    }

    public async Task<IEnumerable<School>> GetSchools()
    {
        return await _schoolPortalContext.Schools.ToListAsync();
    }

    public async Task UpdateSchoolAsync(SchoolDto school, Guid id)
    {
        var schoolToUpdate = await _schoolPortalContext.Schools.FirstOrDefaultAsync(s => s.Id == id);

        if (school is null)
            throw new ArgumentNullException($"School with the Id {id} was not found");

        _schoolPortalContext.Update(school);

        await _store.SaveChangesAsync();
    }
}