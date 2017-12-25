﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolADM.Models
{
    public class EnrolledClass
    {
        public int EnrolledClassId { get; set; }
        public string CourseName { get; set; }

        public DateTime ExamDate { get; set; }
        public int ExamGrade { get; set; }

        public virtual ApplicationUser Student { get; set; }
        public string StudentId { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}