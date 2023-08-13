using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("Channels", Schema = "dbo")]
    public partial class Channel
    {
        public Channel()
        {
            DarkModes = new HashSet<DarkMode>();
            Loans = new HashSet<Loan>();
            RepeatTransactions = new HashSet<RepeatTransaction>();
            Transactions = new HashSet<Transaction>();
            Users = new HashSet<User>();
        }

        [Key]
        public byte Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(DarkMode.Channel))]
        public virtual ICollection<DarkMode> DarkModes { get; set; }
        [InverseProperty(nameof(Loan.Channel))]
        public virtual ICollection<Loan> Loans { get; set; }
        [InverseProperty(nameof(RepeatTransaction.Channel))]
        public virtual ICollection<RepeatTransaction> RepeatTransactions { get; set; }
        [InverseProperty(nameof(Transaction.Channel))]
        public virtual ICollection<Transaction> Transactions { get; set; }
        [InverseProperty(nameof(User.Channel))]
        public virtual ICollection<User> Users { get; set; }
    }
}
