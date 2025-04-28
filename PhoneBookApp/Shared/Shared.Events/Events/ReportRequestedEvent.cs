using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events.Events
{
    public class ReportRequestedEvent
    {
        public Guid ReportId { get; set; }
    }
}
