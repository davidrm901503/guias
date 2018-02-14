using System.ComponentModel.DataAnnotations;

namespace EventsManager.Web.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "IsRequired")]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string RegisterEmail { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "IsRequired")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string RegisterPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("RegisterPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string RegisterConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "IsRequired")]
        [Display(Name = "Condiciones de uso")]
        public bool AcceptConditions { get; set; }

        public string Location { get; set; }
    }
}