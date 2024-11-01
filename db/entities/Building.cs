using System;

namespace PropertyErrandsService.db.entities;

public class Building
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public int PropertyId { get; set; }
    public required Property Property { get; set; }

    public ICollection<Unit>? Units { get; set; }
}
