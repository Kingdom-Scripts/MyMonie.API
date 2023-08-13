using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("LoanRepayments", Schema = "dbo")]
    public partial class LoanRepayment
    {
        [Key]
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int AccountId { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("LoanRepayments")]
        public virtual Account Account { get; set; } = null!;
        [ForeignKey(nameof(LoanId))]
        [InverseProperty("LoanRepayments")]
        public virtual Loan Loan { get; set; } = null!;
    }
}
