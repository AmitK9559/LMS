using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AdminLogin
    {
        [Key]
        public int ID { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Username { get; set; }

        public string? Designation { get; set; }

        public int RoleID { get; set; }
    }
}
