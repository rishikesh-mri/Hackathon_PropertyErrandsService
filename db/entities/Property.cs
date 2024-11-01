using System;

namespace PropertyErrandsService.db.entities;

public class Property
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public virtual ICollection<Building>? Buildings { get; set; }
}
