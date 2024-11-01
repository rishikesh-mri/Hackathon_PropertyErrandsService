using System;

namespace PropertyErrandsService.db.entities;

public class Unit
{
    public int Id { get; set;}

    public required string Name { get; set;}
    public int BuildingId { get; set; }
    public virtual Building Building { get; set; }

    public virtual ICollection<Tenant>? Tenants { get; set; }
}
