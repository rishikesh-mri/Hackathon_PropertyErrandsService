using PropertyErrandsService.db.entities;

namespace PropertyErrandsService.db.models;

public enum MaintenanceJobStatusId : int
{
    Logged = 0 ,
    InProgress = 1,
    Completed = 2
}

public record MaintenanceJobStatus {
    public MaintenanceJobStatusId MaintenanceJobStatusId { get; set; }
    public required string Name { get; set; }

    public ICollection<MaintenanceJob>? MaintenanceJobs { get; set; }

}