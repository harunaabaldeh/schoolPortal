namespace API.Entities;

public class School
{
    public Guid Id { get; set; }
    public string SchoolCode { get; set; }
    public string SchoolName { get; set; }
    public string PrincipleName { get; set; }
    public Guid RegionId { get; set; }
    public Region Region { get; set; }
}
