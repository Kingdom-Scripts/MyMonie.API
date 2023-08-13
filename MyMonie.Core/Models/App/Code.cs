using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("Codes", Schema = "dbo")]
    public partial class Code
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Column("Code")]
        [StringLength(6)]
        [Unicode(false)]
        public string Code1 { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsUsed { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Codes")]
        public virtual User User { get; set; } = null!;
    }
}
