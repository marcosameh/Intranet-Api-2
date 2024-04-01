using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.DBGeneratedModel
{
    public class Almanac
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="عفواً يرجى ادخال اسم الحدث")]
        public string Name { get; set;}
        [Required(ErrorMessage = "عفواً يرجى ادخال التاريخ المحدد")]
        public DateTime DateSelected { get; set; }
        [Required(ErrorMessage = "عفواً يرجى ادخال التاريخ المحدد")]
        public string Details { get; set; }
        [Required(ErrorMessage = "عفواً يرجى ادخال ساعة البداية")]
        public TimeSpan StartTime { get; set; }
        [Required(ErrorMessage = "عفواً يرجى ادخال ساعة النهاية")]
        public TimeSpan EndTime { get; set; }
    }
}
