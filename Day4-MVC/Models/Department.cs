using System.ComponentModel.DataAnnotations;

namespace MVC_DAY2.Models
{
    public  class Department
    {
        [Key]
        public int DeptId { get; set; }
    
        public string DeptName { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}