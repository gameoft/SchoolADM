using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SchoolADM.Models;

namespace SchoolADM.DataLayer
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {

            //// Configure StudentId as PK for StudentAddress
            //HasKey(c => c.StudentId);

            //// Property(c => c.StudentId).HasColumnName("StudentId");


            Property(c => c.CourseName)
                .HasMaxLength(250)
                .IsFixedLength()
                .IsRequired();


            HasMany<EnrolledClass>(g => g.EnrolledClasses)
            .WithRequired(s => s.Course)
            .HasForeignKey<int>(s => s.CourseId)
            .WillCascadeOnDelete(false);

            HasRequired<ApplicationUser>(x => x.Teacher)
                .WithMany(x => x.CoursesTaught)
                .HasForeignKey<string>(x => x.TeacherId)
                .WillCascadeOnDelete(false);
        }
    }
}