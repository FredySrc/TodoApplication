using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApplication.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Display(Name ="Categoría")]
        [MinLength(3, ErrorMessage = "EL maximo es 3 caracteres")]
        [StringLength(30, ErrorMessage = "EL maximo es 30 caracteres")]
        public string CategoryName { get; set; }

        public IEnumerable<TodoNote> TodoNotes { get; set; }
    }
}
