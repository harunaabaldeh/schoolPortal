using API.Dtos;
using API.Entities;

namespace API.IRepositories;
public interface ISchoolRepository
{
    Task CreateSchoolAsync(SchoolDto school);
    Task UpdateSchoolAsync(SchoolDto school, Guid id);
    Task<IEnumerable<School>> GetSchools();
    Task<School> GetSchoolById(Guid id);
}