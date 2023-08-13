using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App
{
    [Table("Currencies", Schema = "dbo")]
    public partial class Currency
    {
        public Currency()
        {
            UserSettingPrimaryCurrencies = new HashSet<UserSetting>();
            UserSettingSecondaryCurrencies = new HashSet<UserSetting>();
        }

        [Key]
        public byte Id { get; set; }
        [StringLength(5)]
        public string CountryCode { get; set; } = null!;
        [StringLength(5)]
        public string Symbol { get; set; } = null!;

        [InverseProperty(nameof(UserSetting.PrimaryCurrency))]
        public virtual ICollection<UserSetting> UserSettingPrimaryCurrencies { get; set; }
        [InverseProperty(nameof(UserSetting.SecondaryCurrency))]
        public virtual ICollection<UserSetting> UserSettingSecondaryCurrencies { get; set; }
    }
}
