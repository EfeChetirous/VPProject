using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPProject.Data.Repository;

namespace VPProject.Models.Entities
{
    public class Country : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountrySetting CountrySetting { get; set; }
        public ICollection<CountryHoliday> CountryHolidays { get; set; }

    }
}
