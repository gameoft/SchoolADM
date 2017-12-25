using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace SchoolADM.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Address { get; set; }


        ////readonly properties non impattano EF che li ignora
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        //public string AddressBlock
        //{
        //    get
        //    {
        //        string addressBlock = string.Format("{0}<br/>{1}, {2} {3}", Address, City, State, ZipCode).Trim();
        //        return addressBlock == "<br/>," ? string.Empty : addressBlock;
        //    }
        //}

        public List<EnrolledClass> StudentEnrollments { get; set; }
        public List<Course> CoursesTaught { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }

   
}