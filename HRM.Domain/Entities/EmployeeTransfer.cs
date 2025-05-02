using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRM.Domain.Entities
{
    public partial class EmployeeTransfer
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int? FromDepartmentId { get; set; }

        public int? ToDepartmentId { get; set; }

        public int? FromPositionId { get; set; }

        public int? ToPositionId { get; set; }

        public DateOnly TransferDate { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("EmployeeTransfers")]
        public virtual Employee Employee { get; set; } = null!;

        [ForeignKey("FromDepartmentId")]
        [InverseProperty("EmployeeTransferFromDepartments")]
        public virtual Department? FromDepartment { get; set; }

        [ForeignKey("FromPositionId")]
        [InverseProperty("EmployeeTransferFromPositions")]
        public virtual Position? FromPosition { get; set; }

        [ForeignKey("ToDepartmentId")]
        [InverseProperty("EmployeeTransferToDepartments")]
        public virtual Department? ToDepartment { get; set; }

        [ForeignKey("ToPositionId")]
        [InverseProperty("EmployeeTransferToPositions")]
        public virtual Position? ToPosition { get; set; }
    }
}