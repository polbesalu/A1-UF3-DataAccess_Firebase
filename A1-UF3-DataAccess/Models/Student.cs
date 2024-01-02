using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_UF3_DataAccess.Models
{
    public class Student
    {
        public string FullName { get; set; }
        public Cicle CurseCicle { get; set; }
        public string Dual { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public int AverageScore { get; set; }
    }
}
