using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("UserCategories", Schema = "dbo")]
    public partial class UserCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Key]
        public int UserId { get; set; }
        public short TransactionTypeId { get; set; }
        public int? ParentId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("UserCategoryCategories")]
        public virtual Category Category { get; set; } = null!;
        [ForeignKey(nameof(ParentId))]
        [InverseProperty("UserCategoryParents")]
        public virtual Category? Parent { get; set; }
        [ForeignKey(nameof(TransactionTypeId))]
        [InverseProperty("UserCategories")]
        public virtual TransactionType TransactionType { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserCategories")]
        public virtual User User { get; set; } = null!;
    }
}
