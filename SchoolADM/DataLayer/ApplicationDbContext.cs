using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SchoolADM.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolADM.DataLayer
{
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

            //To turn off lazy loading for a particular property, do not make it virtual. To turn off lazy loading for all entities in the context, set its configuration property to false
            //this.Configuration.LazyLoadingEnabled = false;
        }

     
        public DbSet<CoursePath> CoursePath { get; set; }
        public DbSet<Course> Course { get; set; }

        //public DbSet<Standard> Standards { get; set; }


        //explicit loading
        //var student = context.Students
        //               .Where(s => s.FirstName == "Bill")
        //               .FirstOrDefault<Student>();

        //context.Entry(student).Reference(s => s.Address).Load(); // loads StudentAddress 
        //context.Entry(student).Collection(s => s.StudentCourses).Load(); // loads StudentCourses collection 

        //querying related entities 
        //var student = context.Students
        //           .Where(s => s.FirstName == "Bill")
        //           .FirstOrDefault<Student>();

        //context.Entry(student).Collection(s => s.StudentCourses).Query().Where(sc => sc.CourseName == "Maths").FirstOrDefault();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new CoursePathConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());



            //modelBuilder.Configurations.Add(new CategoryConfiguration());
            //modelBuilder.Configurations.Add(new CustomerConfiguration());
            //modelBuilder.Configurations.Add(new InventoryItemConfiguration());

            //modelBuilder.Configurations.Add(new PartConfiguration());

            //modelBuilder.Configurations.Add(new WorkOrderConfiguration());
            //modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            //modelBuilder.Configurations.Add(new LogEntryConfiguration());
            //modelBuilder.Configurations.Add(new WidgetConfiguration());








            base.OnModelCreating(modelBuilder);
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

      
        //public System.Data.Entity.DbSet<MasterDetail.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<MasterDetail.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<MasterDetail.Models.ApplicationRole> IdentityRoles { get; set; }
    }
}