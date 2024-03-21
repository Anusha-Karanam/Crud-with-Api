using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_CRUD_API.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(30, ErrorMessage = "First Name must be between 1 and 30 characters", MinimumLength = 1)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(30, ErrorMessage = "Last Name must be between 1 and 30 characters", MinimumLength = 1)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(100, ErrorMessage = "Address must be less than 100 characters")]
        public string? Address { get; set; }

        [StringLength(25, ErrorMessage = "City must be less than 25 characters")]
        public string? City { get; set; }

        [StringLength(2, ErrorMessage = "State Code must be 2 characters")]
        public string? StateCode { get; set; }

        [StringLength(5, ErrorMessage = "Zip Code must be 5 characters")]
        public string? ZipCode { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        public long? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Salary is required")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Department Id is required")]
        public int DepartmentId { get; set; }
        //public Department? Department { get; set; }
    }



}

