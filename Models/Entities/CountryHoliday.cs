using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPProject.Data.Repository;

namespace VPProject.Models.Entities
{
    public class CountryHoliday : BaseEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public DateTime HolidayDate { get; set; }
        public Country Country { get; set; }

    }
}
