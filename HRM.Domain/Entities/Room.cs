using System;
using System.Collections.Generic;

namespace HRM.Domain.Entities;

public partial class Room
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string? Description { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<EmployeeTransfer> EmployeeTransferFromRooms { get; set; } = new List<EmployeeTransfer>();

    public virtual ICollection<EmployeeTransfer> EmployeeTransferToRooms { get; set; } = new List<EmployeeTransfer>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
