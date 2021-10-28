using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Actors
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Must begin with uppercase letter")]
        [StringLength(60, MinimumLength = 2)]
        [Required]
        [Display(Name = "First name")]
        public string Firstname { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Must begin with uppercase letter")]
        [StringLength(60, MinimumLength = 2)]
        [Required]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Must begin with uppercase letter")]
        [Required]
        [StringLength(100)]
        public string Skills { get; set; }

        [Range(0,int.MaxValue, ErrorMessage = "Can't be negative")]
        [Display(Name = "Net worth")]
        public decimal Networth { get; set; }
    }
}