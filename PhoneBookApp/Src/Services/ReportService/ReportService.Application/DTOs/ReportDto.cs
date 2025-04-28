using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.DTOs
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public DateTime RequestedAt { get; set; }
        public string Status { get; set; } // Enum'u string olarak döneceğiz
        public string? FilePath { get; set; } // CSV dosyasının yolu
    }
}
