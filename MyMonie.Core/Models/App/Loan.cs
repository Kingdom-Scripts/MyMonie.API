using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("Loans", Schema = "dbo")]
    public partial class Loan
    {
        public Loan()
        {
            LoanInterests = new HashSet<LoanInterest>();
            LoanRepayments = new HashSet<LoanRepayment>();
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public int? InterestId { get; set; }
        [StringLength(4)]
        [Unicode(false)]
        public string LoanType { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
        [Column(TypeName = "money")]
        public decimal RepaymentAmountPerPeriod { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string RepaymentInterval { get; set; } = null!;
        public bool IsFullyPaid { get; set; }
        public DateTime? FullRepaymentDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DeadlineDate { get; set; }
        public byte ChannelId { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Loans")]
        public virtual Account Account { get; set; } = null!;
        [ForeignKey(nameof(ChannelId))]
        [InverseProperty("Loans")]
        public virtual Channel Channel { get; set; } = null!;
        [ForeignKey(nameof(InterestId))]
        [InverseProperty(nameof(LoanInterest.Loans))]
        public virtual LoanInterest? Interest { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Loans")]
        public virtual User User { get; set; } = null!;
        [InverseProperty(nameof(LoanInterest.Loan))]
        public virtual ICollection<LoanInterest> LoanInterests { get; set; }
        [InverseProperty(nameof(LoanRepayment.Loan))]
        public virtual ICollection<LoanRepayment> LoanRepayments { get; set; }
    }
}
