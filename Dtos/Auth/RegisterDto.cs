

using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Dtos.Auth
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(80, ErrorMessage = "El nombre completo no puede tener mas de 80 carácteres")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "El email es requerido.")]
        [EmailAddress(ErrorMessage = "Ingrese una direccion de email valida.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "La confirmacion de la contraseña es requerida.")]
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas deben ser iguales.")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}