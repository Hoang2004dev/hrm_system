using System;
using System.Collections.Generic;

namespace HRM.Domain.Entities;

public partial class SystemLog
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Action { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
