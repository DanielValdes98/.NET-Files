using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // *
using System.ComponentModel;
using Antlr.Runtime.Tree;

namespace CRUD_BASICO.Models.TableViewModels
{
    public class UserViewModel
    {

        // Los DataAnnotations sirven para agregar validaciones:

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Edad")]
        public int? Edad { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        [DisplayName("Correo eléctronico")]
        public string Email { get; set; }
    }

    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Edad")] 
        public int? Edad { get; set;}

        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "El {0} debe contener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set;}
    }
}