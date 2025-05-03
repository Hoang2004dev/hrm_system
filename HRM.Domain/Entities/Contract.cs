using System;
using System.Collections.Generic;

namespace HRM.Domain.Entities;

public partial class Contract
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string? ContractType { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Salary { get; set; }

    public string? Note { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
