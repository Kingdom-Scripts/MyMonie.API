using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("Transactions", Schema = "dbo")]
    public partial class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public short TransactionTypeId { get; set; }
        public byte ChannelId { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Transactions")]
        public virtual Category Category { get; set; } = null!;
        [ForeignKey(nameof(ChannelId))]
        [InverseProperty("Transactions")]
        public virtual Channel Channel { get; set; } = null!;
        [ForeignKey(nameof(TransactionTypeId))]
        [InverseProperty("Transactions")]
        public virtual TransactionType TransactionType { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Transactions")]
        public virtual User User { get; set; } = null!;
    }
}
