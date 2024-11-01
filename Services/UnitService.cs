using Microsoft.EntityFrameworkCore;
using PropertyErrandsService.db;
using PropertyErrandsService.db.entities;

namespace PropertyErrandsService.Services;

public class UnitService
{

    public async Task<IList<Unit>> GetUnitsAsync(int buildingId)
    {
        using (var db = new PESDbContext())
        {
            var units = await db.Units.Where(u => u.BuildingId == buildingId).ToListAsync();
            return units;
        }
    }

    public async Task<Unit> GetUnitByIdAsync(int unitId)
    {
        using (var db = new PESDbContext())
        {
            var unit = await db.Units.SingleOrDefaultAsync(u => u.Id == unitId);
            return unit;
        }
    }
}
