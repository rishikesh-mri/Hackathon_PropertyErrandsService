using Microsoft.EntityFrameworkCore;
using PropertyErrandsService.db;
using PropertyErrandsService.db.entities;

namespace PropertyErrandsService.Services;

public class BuildingService
{
    public async Task<IList<Building>> GetBuildings(int propertyId)
    {
        using (var db = new PESDbContext())  
        {
            var buildings = await db.Buildings.Where(b => b.PropertyId == propertyId).ToListAsync();
            return buildings;
        }
    }

    public async Task<Building> GetBuilding(int buildingId)
    {
        using (var db = new PESDbContext())
        {
            var building = await db.Buildings.SingleOrDefaultAsync(b => b.Id == buildingId);
            return building;
        }
    }
}
