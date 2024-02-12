using API.Data;

namespace API.StoreChanges;
public class Store : IStore
{
    private readonly SchoolPortalContext _schoolPortalContext;
    public Store(SchoolPortalContext schoolPortalContext)
    {
        _schoolPortalContext = schoolPortalContext;
    }
    public async Task SaveChangesAsync()
    {
        await _schoolPortalContext.SaveChangesAsync();
    }
}
