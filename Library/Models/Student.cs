using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Student
    {
        [Key]
        public Int64 StudentId { get; set; }
        [Required(ErrorMessage ="Enter First Name")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Enter Father Name")]
        public string? FatherName { get; set; }

        [Required(ErrorMessage = "Enter Mobile No")]
        [Range(1000000000,9999999999,ErrorMessage ="Enter Correct Number")]
        public string? MobileNo { get; set; }
        public string? AlterNateMobileNo { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Select Timing")]
        public int LibraryTime { get; set; }

        [Required(ErrorMessage = "Enter EmailID")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? EmailID { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public bool IsActive { get; set; }

    }

    public class StudentList
    {
        public List<Student> Students { get; set; }
    }
}
