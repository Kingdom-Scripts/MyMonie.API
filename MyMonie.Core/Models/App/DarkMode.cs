using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("DarkModes", Schema = "dbo")]
    public partial class DarkMode
    {
        [Key]
        public int UserId { get; set; }
        public byte ChannelId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey(nameof(ChannelId))]
        [InverseProperty("DarkModes")]
        public virtual Channel Channel { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        [InverseProperty("DarkMode")]
        public virtual User User { get; set; } = null!;
    }
}
