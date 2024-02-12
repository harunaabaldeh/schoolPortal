using API.Entities;

namespace API.Dtos;
public class SchoolDto
{
    public string SchoolCode { get; set; }
    public string SchoolName { get; set; }
    public string PrincipleName { get; set; }
    public Guid RegionId { get; set; }
}
