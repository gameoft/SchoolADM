using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolADM.Models
{
    public class CoursePath
    {
     
        public CoursePath()
        {
            //this.Courses = new HashSet<Course>();
        }
        public int CoursePathId { get; set; }
        public string CoursePathName { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        //public byte[] Photo { get; set; }
        //public decimal Height { get; set; }
        //public float Weight { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        //One-to-Zero-or-One
        //public virtual Course Address { get; set; }

        
        
        ////Foreign key for Standard
        //public int StandardId { get; set; }
        //public Standard Standard { get; set; }

        //public int CurrentGradeId { get; set; }
        //public Grade CurrentGrade { get; set; }

        ////many-to-many
        //public virtual ICollection<Course> Courses { get; set; }
    }

 

    //public class EnrolledClass
    //{

    //}

    //public class Grade
    //{
    //    public int GradeId { get; set; }
    //    public string GradeName { get; set; }
    //    public string Section { get; set; }

    //    public ICollection<Student> Students { get; set; }
    //}

    //public class Course
    //{
    //    public Course()
    //    {
    //        this.Students = new HashSet<Student>();
    //    }

    //    public int CourseId { get; set; }
    //    public string CourseName { get; set; }

    //    public virtual ICollection<Student> Students { get; set; }
    //}

    //public class Standard
    //{
    //    public Standard()
    //    {

    //    }
    //    public int StandardId { get; set; }
    //    public string StandardName { get; set; }

    //    public IList<Student> Students { get; set; }

    //}

    //public class Teacher
    //{
    //    public int TeacherId { get; set; }
    //    public string TeacherName { get; set; }
    //}
}