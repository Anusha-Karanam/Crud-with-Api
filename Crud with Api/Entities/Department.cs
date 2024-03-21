using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_CRUD_API.Entities
{
    [Table("Department")]
    public class Department
    {

        [Key]
        [Column("DepartmentId")]
        public int Id { get; set; } 

        public required string Name { get; set; } = null!;

       
    }
}
