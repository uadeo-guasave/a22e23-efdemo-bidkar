using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDemo.Models
{
    class Profile
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string PublicEmail { get; set; }
        [MaxLength(50)]
        public string Facebook { get; set; }
        [MaxLength(50)]
        public string Twitter { get; set; }
        [MaxLength(50)]
        public string Linkedin { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        [NotMapped]
        public User User { get; set; }
    }
}