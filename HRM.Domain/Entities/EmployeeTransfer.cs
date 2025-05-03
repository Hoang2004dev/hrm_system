using System;
using System.Collections.Generic;

namespace HRM.Domain.Entities;

public partial class EmployeeTransfer
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int? FromRoomId { get; set; }

    public int? ToRoomId { get; set; }

    public DateOnly TransferDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Room? FromRoom { get; set; }

    public virtual Room? ToRoom { get; set; }
}
