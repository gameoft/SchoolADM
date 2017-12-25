using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SchoolADM.Models;

namespace SchoolADM.DataLayer
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(au => au.FirstName).HasMaxLength(15).IsOptional();
            Property(au => au.LastName).HasMaxLength(15).IsOptional();

            //Property(au => au.Address).HasMaxLength(30).IsOptional();

            //HasOptional(s => s.e.Address)
            //            .WithRequired(ad => ad.Student);


            Ignore(au => au.RolesList);
        }
    }
}