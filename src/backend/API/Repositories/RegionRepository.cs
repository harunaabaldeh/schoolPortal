using API.Data;
using API.Dtos;
using API.Entities;
using API.IRepositories;
using API.StoreChanges;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;
public class RegionRepository : IRegionRepository
{
    private readonly SchoolPortalContext _schoolPortalContext;
    private readonly IStore _store;
    public RegionRepository(SchoolPortalContext schoolPortalContext, IStore store)
    {
        _schoolPortalContext = schoolPortalContext;
        _store = store;
    }
    public async Task CreateRegion(RegionDto regionDto)
    {
        var region = new Region
        {
            RegionName = regionDto.RegionName,
        };

        await _schoolPortalContext.Regions.AddAsync(region);

        await _store.SaveChangesAsync();
    }

    public async Task<Region> GetRegion(Guid id)
    {
        var region = await _schoolPortalContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

        if (region == null)
            throw new ArgumentNullException($"Region with the Id {id} was not found");

        return region;
    }

    public async Task<IEnumerable<Region>> GetRegions()
    {
        return await _schoolPortalContext.Regions.ToListAsync();
    }
}