using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApplication.Models
{
    public class TodoNote
    {
        [Key]
        public int TodoNoteID { get; set; }

        [Display(Name ="Título")]
        [MinLength(3, ErrorMessage = "EL maximo es 3 caracteres")]
        [StringLength(30, ErrorMessage = "EL maximo es 30 caracteres")]
        public string Title { get; set; }

        [Display(Name ="Fecha Inicio")]
        public DateTime StarDate { get; set; }

        [Display(Name ="Fecha Final")]
        public DateTime DueTime { get; set; }

        [Display(Name ="Completada")]
        public Boolean IsComplete { get; set; }

        [Display(Name ="Contenido")]
        [MinLength(4, ErrorMessage = "EL maximo es 4 caracteres")]
        [StringLength(250, ErrorMessage = "EL maximo es 250 caracteres")]
        public string NoteContent { get; set; }

        [Display(Name = "Categoría")]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Categorie { get; set; }
    }
}
