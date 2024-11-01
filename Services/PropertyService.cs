using System;
using Microsoft.EntityFrameworkCore;
using PropertyErrandsService.db;
using PropertyErrandsService.db.entities;

namespace PropertyErrandsService.Services;

public class PropertyService()
{
    public async Task<IList<Property>> GetPropertiesAsync(string propertyName)
    {
        using (var db = new PESDbContext())
        {
            var properties = await db.Properties.ToListAsync();
            return properties;
        }
    }

    public async Task<Property> GetPropertyAsync(int propertyId)
    {
        using (var db = new PESDbContext())
        {
            var property = await db.Properties.SingleOrDefaultAsync(p => p.Id == propertyId);
            return property;
        }
    }
}
