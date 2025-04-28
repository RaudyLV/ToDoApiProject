using Microsoft.AspNetCore.Identity;

namespace ToDoApi.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}