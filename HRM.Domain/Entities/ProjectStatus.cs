using System;
using System.Collections.Generic;

namespace HRM.Domain.Entities;

public partial class ProjectStatus
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly FromDate { get; set; }

    public DateOnly? ToDate { get; set; }

    public virtual Project Project { get; set; } = null!;
}

//('Planned'),
//('InProgress'),
//('OnHold'),
//('Completed'),
//('Cancelled');