
using static ReportService.Domain.Enums.Enums;

namespace ReportService.Domain.Entities
{
    public class Report
    {
        public Guid Id { get; set; }
        public DateTime RequestedAt { get; set; }
        public ReportStatus Status { get; set; }
        public string? FilePath { get; set; }
    }
}
