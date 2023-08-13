using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("Categories", Schema = "dbo")]
    public partial class Category
    {
        public Category()
        {
            Budgets = new HashSet<Budget>();
            RepeatTransactions = new HashSet<RepeatTransaction>();
            Transactions = new HashSet<Transaction>();
            UserCategoryCategories = new HashSet<UserCategory>();
            UserCategoryParents = new HashSet<UserCategory>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public int CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(User.Categories))]
        public virtual User CreatedBy { get; set; } = null!;
        [InverseProperty(nameof(Budget.Category))]
        public virtual ICollection<Budget> Budgets { get; set; }
        [InverseProperty(nameof(RepeatTransaction.Category))]
        public virtual ICollection<RepeatTransaction> RepeatTransactions { get; set; }
        [InverseProperty(nameof(Transaction.Category))]
        public virtual ICollection<Transaction> Transactions { get; set; }
        [InverseProperty(nameof(UserCategory.Category))]
        public virtual ICollection<UserCategory> UserCategoryCategories { get; set; }
        [InverseProperty(nameof(UserCategory.Parent))]
        public virtual ICollection<UserCategory> UserCategoryParents { get; set; }
    }
}
