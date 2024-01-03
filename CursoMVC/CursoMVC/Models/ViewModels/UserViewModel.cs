using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // *

namespace CursoMVC.Models.ViewModels
{
    public class UserViewModel
    {
        // Los DataAnnotations sirven para agregar validaciones:

        // Un ViewModel es una clase con atributos. Este es el ViewModel para llenar el formulario:
        [Required]
        [EmailAddress]
        [StringLength(100,ErrorMessage = "El {0} debe contener al menos {1} caracteres",MinimumLength =1)]
        [Display(Name ="Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] // Que sea del tipo password
        [Display(Name ="Contraseña")]
        public string Password { get; set; }

        [Display(Name ="Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; } // Es para validar, no se manda a la BD

        [Required]
        public int Edad { get; set; }
    }

    public class EditUserViewModel
    {
        // Los DataAnnotations sirven para agregar validaciones:

        // Un ViewModel es una clase con atributos. Este es el ViewModel para llenar el formulario:

        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe contener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [DataType(DataType.Password)] // Que sea del tipo password
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; } // Es para validar, no se manda a la BD

        [Required]
        public int Edad { get; set; }
    }
}