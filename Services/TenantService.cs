using Microsoft.EntityFrameworkCore;
using PropertyErrandsService.db;
using PropertyErrandsService.db.entities;

namespace PropertyErrandsService.Services;

public class TenantService
{
    public async Task<IList<Tenant>> GetTenants(int unitId)
    {
        using (var db = new PESDbContext()) {
            var tenants = await db.Tenants.Where(t => t.UnitId == unitId).ToListAsync();
            return tenants;
        }
    }

    public async Task<Tenant> GetTenantAsync(int tentnatId)
    {
        using (var db = new PESDbContext()) {
            var tenant = await db.Tenants.FirstOrDefaultAsync(t => t.Id == tentnatId);
            return tenant;
        }
    }
}
