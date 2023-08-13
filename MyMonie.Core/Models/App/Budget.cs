using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("Budgets", Schema = "dbo")]
    [Microsoft.EntityFrameworkCore.Index(nameof(UserId), nameof(Period), nameof(CategoryId), Name = "Budgets_index_0", IsUnique = true)]
    public partial class Budget
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string Period { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Budgets")]
        public virtual Category? Category { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Budgets")]
        public virtual User User { get; set; } = null!;
    }
}