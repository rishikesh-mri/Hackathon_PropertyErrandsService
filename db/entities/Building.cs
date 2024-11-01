using System;

namespace PropertyErrandsService.db.entities;

public class Building
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public int PropertyId { get; set; }
    public virtual Property Property { get; set; }

    public virtual ICollection<Unit>? Units { get; set; }
}
