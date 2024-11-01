using Microsoft.EntityFrameworkCore;
using PropertyErrandsService.db;
using PropertyErrandsService.db.entities;

namespace PropertyErrandsService.Services;

public class MaintenanceJobsService
{
    public async Task<IList<MaintenanceJob>> GetMaintenanceJobsAsync(int supplierId)
    {
        using (var db = new PESDbContext())
        {
            var jobs = await db.MaintenanceJobs.Where(mj => mj.SupplierId == supplierId).ToListAsync();
            return jobs;
        }
    }
}
