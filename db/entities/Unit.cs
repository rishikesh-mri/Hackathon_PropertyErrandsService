using System;

namespace PropertyErrandsService.db.entities;

public class Unit
{
    public int Id { get; set;}

    public required string Name { get; set;}
    public int BuildingId { get; set; }
    public required Building Building { get; set; }

    public ICollection<Tenant>? Tenants { get; set; }
}
