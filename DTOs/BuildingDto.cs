namespace PropertyErrandsService.DTOs;

public record class BuildingDto
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public int PropertyId { get; set; }
}
