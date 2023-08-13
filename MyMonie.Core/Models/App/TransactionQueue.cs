using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("TransactionQueues", Schema = "dbo")]
    public partial class TransactionQueue
    {
        [Key]
        public int Id { get; set; }
        public int RepeatTransactionId { get; set; }
        public DateTime NextExecutionDate { get; set; }
        public bool IsDone { get; set; }

        [ForeignKey(nameof(RepeatTransactionId))]
        [InverseProperty("TransactionQueues")]
        public virtual RepeatTransaction RepeatTransaction { get; set; } = null!;
    }
}
