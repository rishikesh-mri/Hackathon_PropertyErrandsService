using PropertyErrandsService.db.entities;

namespace PropertyErrandsService.DTOs;

public record class PropertyDto
{

    public int Id { get; set; }
    public required string Name { get; set; }

    public IList<BuildingDto>? Buildings { get; set; }
}
