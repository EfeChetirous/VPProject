using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPProject.Data.Repository;

namespace VPProject.Models.Entities
{
    public class CountrySetting : BaseEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string OffDayFirst { get; set; }
        public string OffDaySecond { get; set; }
        public string OffDayThird { get; set; }
        public string Currency { get; set; }
        public decimal PenaltyAmount { get; set; }
        public Country Country { get; set; }
    }
}
