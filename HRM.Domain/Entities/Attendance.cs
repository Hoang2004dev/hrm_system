using System;
using System.Collections.Generic;

namespace HRM.Domain.Entities;

public partial class Attendance
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly? CheckInTime { get; set; }

    public TimeOnly? CheckOutTime { get; set; }

    public string? Note { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
