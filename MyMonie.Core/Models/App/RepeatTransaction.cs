using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("RepeatTransactions", Schema = "dbo")]
    public partial class RepeatTransaction
    {
        public RepeatTransaction()
        {
            TransactionQueues = new HashSet<TransactionQueue>();
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public short TransactionTypeId { get; set; }
        public short IntervalCount { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string IntervalDescription { get; set; } = null!;
        public DateTime? EndDate { get; set; }
        public byte ChannelId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("RepeatTransactions")]
        public virtual Category Category { get; set; } = null!;
        [ForeignKey(nameof(ChannelId))]
        [InverseProperty("RepeatTransactions")]
        public virtual Channel Channel { get; set; } = null!;
        [ForeignKey(nameof(TransactionTypeId))]
        [InverseProperty("RepeatTransactions")]
        public virtual TransactionType TransactionType { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        [InverseProperty("RepeatTransactions")]
        public virtual User User { get; set; } = null!;
        [InverseProperty(nameof(TransactionQueue.RepeatTransaction))]
        public virtual ICollection<TransactionQueue> TransactionQueues { get; set; }
    }
}
