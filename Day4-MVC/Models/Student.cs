using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DAY2.Models
{
    public class Student
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
         public string Address { get; set; }
        public int Age { get; set; }

        [ForeignKey(nameof(Department))]
        public int DeptId { get; set; }
        public Department Department { get; set; }
    }
}
