using System.ComponentModel.DataAnnotations;

namespace EFDemo.Models
{
    class User
    {
        public int Id { get; set; }
        
        [Required, MaxLength(20)]
        public string Name { get; set; } = ""!;
        
        [Required]
        public string Password { get; set; } = ""!;

        [Required, MaxLength(50)]
        public string Firstname { get; set; } = ""!;

        [Required, MaxLength(50)]
        public string Lastname { get; set; } = ""!;

        [Required, EmailAddress]
        public string Email { get; set; } = ""!;

        public string? RememberToken { get; set; }
    }
}