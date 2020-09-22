using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VPProject.Models.UIModels
{
    public class BookInputModel
    {
        public BookInputModel()
        {
            this.BookCheckIn = DateTime.Now;
            this.BookReturn = DateTime.Now;
        }
        [Display(Name = "Book Check In")]
        [Required(ErrorMessage = "Please fill book check out date.")]
        public DateTime BookCheckIn { get; set; }

        [Display(Name = "Book Received")]
        [Required(ErrorMessage = "Please fill book return date")]
        public DateTime BookReturn { get; set; }
        [Display(Name = "Country Selection")]
        public int CountryId { get; set; }
    }
}
