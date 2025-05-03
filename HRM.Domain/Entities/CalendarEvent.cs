using System;
using System.Collections.Generic;

namespace HRM.Domain.Entities;

public partial class CalendarEvent
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsAllDay { get; set; }

    public string? EventType { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;
}
