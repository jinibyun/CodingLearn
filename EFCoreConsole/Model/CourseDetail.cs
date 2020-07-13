using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreConsole.Model
{
    public class CourseDetail
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public virtual Course course { get; set; }
        // public ICollection<Student> Students { get; set; }
    }
}
