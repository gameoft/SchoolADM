using System;
using System.Collections.Generic;
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
  
    public class EnrolledClassConfiguration : EntityTypeConfiguration<EnrolledClass>
    {
        public EnrolledClassConfiguration()
        {

            //// Configure StudentId as PK for StudentAddress
            //HasKey(c => c.StudentId);

            //// Property(c => c.StudentId).HasColumnName("StudentId");


            Property(c => c.CourseName)
                .HasMaxLength(250)
                .IsFixedLength()
                .IsRequired();


            HasRequired<ApplicationUser>(x => x.Student)
                .WithMany(x => x.StudentEnrollments)
                .HasForeignKey<string>(x => x.StudentId)
                .WillCascadeOnDelete(false);

        }
    }
}