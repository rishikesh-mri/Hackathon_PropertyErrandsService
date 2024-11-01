using System;

namespace PropertyErrandsService.db.entities;

public class Supplier
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Email { get; set; }
}
