namespace PropertyErrandsService.db.entities;

public class Tenant
{
    public int Id { get; set;}
    public int UnitId { get; set; }
    public virtual Unit Unit { get; set; }
    public required string Name { get; set;}
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public int AmountOwned { get; set; }
}
