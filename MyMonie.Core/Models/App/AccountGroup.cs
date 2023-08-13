using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("AccountGroups", Schema = "dbo")]
    public partial class AccountGroup
    {
        public AccountGroup()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("AccountGroups")]
        public virtual User User { get; set; } = null!;
        [InverseProperty(nameof(Account.AccountGroup))]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
