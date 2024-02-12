using API.Dtos;
using API.Entities;

namespace API.IRepositories;
public interface IRegionRepository
{
    Task CreateRegion(RegionDto region);
    Task<IEnumerable<Region>> GetRegions();
    Task<Region> GetRegion(Guid id);

}