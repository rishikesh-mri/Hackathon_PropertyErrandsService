using System;
using Microsoft.EntityFrameworkCore;
using PropertyErrandsService.db;
using PropertyErrandsService.db.entities;
using PropertyErrandsService.DTOs;

namespace PropertyErrandsService.Services;

public class PropertyService()
{
    public async Task<IList<PropertyDto>> GetPropertiesAsync(string propertyName)
    {
        using (var db = new PESDbContext())
        {
            var properties = await db.Properties.Include(p => p.Buildings).Select(e => new PropertyDto {
                Id = e.Id,
                Name = e.Name,
                Buildings = e.Buildings.Select(b => new BuildingDto { Id = b.Id, Name = b.Name }).ToList(),
            }).ToListAsync();
            return properties;
        }
    }

    public async Task<PropertyDto> GetPropertyAsync(int propertyId)
    {
        using (var db = new PESDbContext())
        {
            var property = await db.Properties.Include(p => p.Buildings).SingleOrDefaultAsync(p => p.Id == propertyId);
            if (property == null) {
                return null;
            }
            var dto = new PropertyDto {
                Id = property.Id,
                Name = property.Name,
                Buildings = property.Buildings.Select(b => new BuildingDto { Id = b.Id, Name = b.Name }).ToList(),
            };
            return dto;
        }
    }

    public async Task<PropertyDto> GetPropertyByNameAsync(string propertyName)
    {
        using (var db = new PESDbContext())
        {
            var property = await db.Properties.Include(p => p.Buildings).SingleOrDefaultAsync(p => p.Name == propertyName);
            if (property == null) {
                return null;
            }
            var dto = new PropertyDto {
                Id = property.Id,
                Name = property.Name,
                Buildings = property.Buildings.Select(b => new BuildingDto { Id = b.Id, Name = b.Name }).ToList(),
            };
            return dto;
        }
    }
}
