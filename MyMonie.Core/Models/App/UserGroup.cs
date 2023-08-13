using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Keyless]
    [Table("UserGroups", Schema = "dbo")]
    public partial class UserGroup
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public bool IsOwner { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group Group { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;
    }
}
