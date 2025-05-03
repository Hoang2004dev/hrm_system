using System;
using System.Collections.Generic;

namespace HRM.Domain.Entities;

public partial class UserProjectRole
{
    public int UserId { get; set; }

    public int ProjectId { get; set; }

    public int? RoleId { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Role? Role { get; set; }

    public virtual User User { get; set; } = null!;
}
