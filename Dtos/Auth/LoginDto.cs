using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Dtos.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El email es requerido.")]
        [EmailAddress(ErrorMessage = "Ingrese una direccion de email valida.")]
        public string Email {get; set; }  = string.Empty;
        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Password {get; set; } = string.Empty;
    }
}