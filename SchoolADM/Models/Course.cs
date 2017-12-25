using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolADM.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual ApplicationUser Teacher { get; set; }
        public string TeacherId { get; set; }

        public int CoursePathId { get; set; }
        public virtual CoursePath CoursePath { get; set; }

        public virtual ICollection<EnrolledClass> EnrolledClasses { get; set; }

    }

}