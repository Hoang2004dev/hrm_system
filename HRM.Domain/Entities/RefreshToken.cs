﻿using System;
using System.Collections.Generic;

namespace HRM.Domain.Entities;

public partial class RefreshToken
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? RevokedAt { get; set; }

    public int IsActive { get; set; }

    public virtual User User { get; set; } = null!;
}
