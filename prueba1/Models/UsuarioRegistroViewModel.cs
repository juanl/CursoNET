using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using prueba1.Code.Helpers;
using prueba1.Code.Validators;

namespace prueba1.Models
{
    public class UsuarioRegistroViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [System.Web.Mvc.Remote("UserNameAvailable", "User", ErrorMessage = "Nombre de usuario no disponible")]
        [StringLength(16, ErrorMessage = "El nombre de usuario debe tener entre 5 y 16 caractéres", MinimumLength = 5)]
        [RegularExpression(@"^[_a-z0-9]+$", ErrorMessage = "No debe haber espacios, mayúsculas y/o caracteres especiales en el nombre de usuario")]
        public string Username { get; set; }


        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
//        [PasswordStrength(ErrorMessage = "Contraseña débil")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Debe repetir la contraseña")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Es necesario conocer el género")]
        [Display(Name = "Género")]
        public Sexo SexoUsuario { get; set; }
        //        public RulesProvider PasswordRulesProvider { get; set; }

        [EsMayorDeEdad(AllowEquality = false)]
        public DateTime FechaNacimiento { get; set; }

        public UsuarioRegistroViewModel()
        {
            //Provincias = 
            //FechaNacimiento = DateTime.Now.AddYears(- 35).Year;
            //            Birthyear = (DateTime.Now.Year - 35).ToString();
            //            PasswordRulesProvider = new IOL.NET.Site.ViewModels.Validators.Password.PasswordRulesProvider();
        }

        [Required(ErrorMessage = "Debe aceptar los Términos y Condiciones")]
        [DisplayName("Aceptar Términos y condiciones")]
        [BooleanRequired(ErrorMessage = "Debe aceptar los Términos y Condiciones")]
        public bool TermsAndConditions { get; set; }
        public Provincias Provincia { get; set; }
        public int IdPartido { get; set; }
//        public int Localidad { get; set; }
    }
}