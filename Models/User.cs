using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDemo.Models
{
    [Table("Users")]
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

        [NotMapped]
        public string AllName { get => ($"{Firstname} {Lastname}"); }

        [NotMapped]
        public Profile Profile { get; set; }
    }
}