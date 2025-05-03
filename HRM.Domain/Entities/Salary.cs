using System;
using System.Collections.Generic;

namespace HRM.Domain.Entities;

public partial class Salary
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public decimal? BaseSalary { get; set; }

    public decimal? Bonus { get; set; }

    public decimal? Allowance { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
