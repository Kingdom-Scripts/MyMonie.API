using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("LoanInterests", Schema = "dbo")]
    public partial class LoanInterest
    {
        public LoanInterest()
        {
            Loans = new HashSet<Loan>();
        }

        [Key]
        public int Id { get; set; }
        public int LoanId { get; set; }
        public short Percentage { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string Interval { get; set; } = null!;
        [StringLength(13)]
        [Unicode(false)]
        public string PaymentScheme { get; set; } = null!;

        [ForeignKey(nameof(LoanId))]
        [InverseProperty("LoanInterests")]
        public virtual Loan Loan { get; set; } = null!;
        [InverseProperty("Interest")]
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
