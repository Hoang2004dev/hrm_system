using System;
using System.Collections.Generic;

namespace HRM.Domain.Entities;

public partial class Position
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Level { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<EmployeeTransfer> EmployeeTransferFromPositions { get; set; } = new List<EmployeeTransfer>();

    public virtual ICollection<EmployeeTransfer> EmployeeTransferToPositions { get; set; } = new List<EmployeeTransfer>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
