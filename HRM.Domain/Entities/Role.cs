using System;
using System.Collections.Generic;

namespace HRM.Domain.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<UserProjectRole> UserProjectRoles { get; set; } = new List<UserProjectRole>();
}
