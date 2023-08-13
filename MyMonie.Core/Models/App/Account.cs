using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("Accounts", Schema = "dbo")]
    public partial class Account
    {
        public Account()
        {
            LoanRepayments = new HashSet<LoanRepayment>();
            Loans = new HashSet<Loan>();
        }

        [Key]
        public int Id { get; set; }
        public int AccountGroupId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
        public bool RecordAsExpense { get; set; }
        [StringLength(2000)]
        [Unicode(false)]
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        [ForeignKey(nameof(AccountGroupId))]
        [InverseProperty("Accounts")]
        public virtual AccountGroup AccountGroup { get; set; } = null!;
        [InverseProperty(nameof(LoanRepayment.Account))]
        public virtual ICollection<LoanRepayment> LoanRepayments { get; set; }
        [InverseProperty(nameof(Loan.Account))]
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
