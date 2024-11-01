using System;
using PropertyErrandsService.db.models;

namespace PropertyErrandsService.db.entities;

public class MaintenanceJob
{
    public int Id { get; set;}
    public int SupplierId { get; set; }
    public virtual Supplier Supplier { get; set; }

    public int? TenantId { get; set; }
    public Tenant? Tenant { get; set; }

    public MaintenanceJobStatusId MaintenanceJobStatusId { get; set; }
    public virtual MaintenanceJobStatus MaintenanceJobStatus { get; set; }
}
