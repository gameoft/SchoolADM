namespace SchoolADM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using SchoolADM.DataLayer;
    using SchoolADM.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolADM.DataLayer.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolADM.DataLayer.ApplicationDbContext context)
        {
            try
            {
                //if (System.Diagnostics.Debugger.IsAttached == false)
                //    System.Diagnostics.Debugger.Launch();
                
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

                userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };
                userManager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 5,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                #region roles
                var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new ApplicationDbContext()));
                if (null == roleManager.FindByName("Student"))
                {
                    var roleResult = roleManager.Create(new ApplicationRole("Student"));
                }
                if (null == roleManager.FindByName("Teacher"))
                {
                    var roleResult = roleManager.Create(new ApplicationRole("Teacher"));
                }
                #endregion roles

                #region admin
                string roleNameAdmin = "Admin";
                var roleAdmin = roleManager.FindByName(roleNameAdmin);
                if (roleAdmin == null)
                {
                    roleAdmin = new ApplicationRole(roleNameAdmin);
                    var roleResult = roleManager.Create(roleAdmin);
                }
                
                string adminName = "admin@admin.com";
                string password = "admin";
                string firstName = "Admin";
                
                var user = userManager.FindByName(adminName);
                if (user == null)
                {
                    user = new ApplicationUser { UserName = adminName, Email = adminName, FirstName = firstName };
                    var result = userManager.Create(user, password);
                    result = userManager.SetLockoutEnabled(user.Id, false);
                }
                var rolesForUser = userManager.GetRoles(user.Id);
                if (!rolesForUser.Contains(roleAdmin.Name))
                {
                    var result = userManager.AddToRole(user.Id, roleAdmin.Name);
                }
                #endregion admin

                #region other users

                if (null == userManager.FindByName("student1@school.com"))
                {
                    user = new ApplicationUser {
                        UserName = "student1@school.com",
                        Email = "student1@school.com",
                        FirstName = "Name1",
                        LastName = "Surname1"
                    };
                    var result = userManager.Create(user, "student1");

                    if (0 == user.Claims.Where(c => c.ClaimType == ClaimTypes.DateOfBirth).Count())
                        userManager.AddClaim(user.Id, new Claim(ClaimTypes.DateOfBirth, "1980-11-22"));
                    if (0 == user.Claims.Where(c => c.ClaimType == ClaimTypes.StreetAddress).Count())
                        userManager.AddClaim(user.Id, new Claim(ClaimTypes.StreetAddress, "address1"));
                    if (0 == user.Claims.Where(c => c.ClaimType == "MobilePhone").Count())
                        userManager.AddClaim(user.Id, new Claim("MobilePhone", "123456"));
                    
                }

                if (null == userManager.FindByName("student2@school.com"))
                {
                    user = new ApplicationUser
                    {
                        UserName = "student2@school.com",
                        Email = "student2@school.com",
                        FirstName = "Name2",
                        LastName = "Surname2"
                    };
                    var result = userManager.Create(user, "student2");
                    
                    if (0 == user.Claims.Where(c => c.ClaimType == ClaimTypes.DateOfBirth).Count())
                        userManager.AddClaim(user.Id, new Claim(ClaimTypes.DateOfBirth, "1970-12-10"));
                    if (0 == user.Claims.Where(c => c.ClaimType == ClaimTypes.StreetAddress).Count())
                        userManager.AddClaim(user.Id, new Claim(ClaimTypes.StreetAddress, "address2"));
                    if (0 == user.Claims.Where(c => c.ClaimType == "MobilePhone").Count())
                        userManager.AddClaim(user.Id, new Claim("MobilePhone", "555-55555"));
                }

                if (null == userManager.FindByName("student3@school.com"))
                {
                    user = new ApplicationUser
                    {
                        UserName = "student3@school.com",
                        Email = "student3@school.com",
                        FirstName = "Name3",
                        LastName = "Surname3"
                    };
                    var result = userManager.Create(user, "student3");

                    if (0 == user.Claims.Where(c => c.ClaimType == ClaimTypes.DateOfBirth).Count())
                        userManager.AddClaim(user.Id, new Claim(ClaimTypes.DateOfBirth, "1990-03-21"));
                    if (0 == user.Claims.Where(c => c.ClaimType == ClaimTypes.StreetAddress).Count())
                        userManager.AddClaim(user.Id, new Claim(ClaimTypes.StreetAddress, "address3"));
                    if (0 == user.Claims.Where(c => c.ClaimType == "MobilePhone").Count())
                        userManager.AddClaim(user.Id, new Claim("MobilePhone", "987654"));
                    
                }

                if (null == userManager.FindByName("student4@school.com"))
                {
                    user = new ApplicationUser
                    {
                        UserName = "student4@school.com",
                        Email = "student4@school.com",
                        FirstName = "Name4",
                        LastName = "Surname4"
                    };
                    var result = userManager.Create(user, "student4");

                    if (0 == user.Claims.Where(c => c.ClaimType == ClaimTypes.DateOfBirth).Count())
                        userManager.AddClaim(user.Id, new Claim(ClaimTypes.DateOfBirth, "1982-05-05"));
                    if (0 == user.Claims.Where(c => c.ClaimType == ClaimTypes.StreetAddress).Count())
                        userManager.AddClaim(user.Id, new Claim(ClaimTypes.StreetAddress, "address4"));
                    if (0 == user.Claims.Where(c => c.ClaimType == "MobilePhone").Count())
                        userManager.AddClaim(user.Id, new Claim("MobilePhone", "456789"));
                }

                if (null == userManager.FindByName("teacher1@school.com"))
                {
                    user = new ApplicationUser
                    {
                        UserName = "teacher1@school.com",
                        Email = "teacher1@school.com",
                        FirstName = "NameT1",
                        LastName = "SurnameT1"
                    };
                    var result = userManager.Create(user, "teacher1");
                    
                    if (0 == user.Claims.Where(c => c.ClaimType == "Department").Count())
                        userManager.AddClaim(user.Id, new Claim("Department", "Systems"));
                    if (0 == user.Claims.Where(c => c.ClaimType == "MobilePhone").Count())
                        userManager.AddClaim(user.Id, new Claim("MobilePhone", "222-222222222222"));


                }

                if (null == userManager.FindByName("teacher2@school.com"))
                {
                    user = new ApplicationUser
                    {
                        UserName = "teacher2@school.com",
                        Email = "teacher2@school.com",
                        FirstName = "NameT2",
                        LastName = "SurnameT2"
                    };
                    var result = userManager.Create(user, "teacher2");
                    
                    if (0 == user.Claims.Where(c => c.ClaimType == "Department").Count())
                        userManager.AddClaim(user.Id, new Claim("Department", "Bioinformatics"));
                    if (0 == user.Claims.Where(c => c.ClaimType == "MobilePhone").Count())
                        userManager.AddClaim(user.Id, new Claim("MobilePhone", "333-33333"));
                }

                if (null == userManager.FindByName("teacher3@school.com"))
                {
                    user = new ApplicationUser
                    {
                        UserName = "teacher3@school.com",
                        Email = "teacher3@school.com",
                        FirstName = "NameT3",
                        LastName = "SurnameT3"
                    };
                    var result = userManager.Create(user, "teacher3");

                    if (0 == user.Claims.Where(c => c.ClaimType == "Department").Count())
                        userManager.AddClaim(user.Id, new Claim("Department", "Big Data Analytics"));
                    if (0 == user.Claims.Where(c => c.ClaimType == "MobilePhone").Count())
                        userManager.AddClaim(user.Id, new Claim("MobilePhone", "345-345345345"));

                }
                #endregion other users

                //context.SaveChanges();

                ////////////////////

                #region coursepaths

                context.CoursePath.AddOrUpdate(
                    c => c.CoursePathId,
                    new CoursePath
                    {
                        CoursePathId = 1,
                        CoursePathName = "Applied Math"
                    });


                context.CoursePath.AddOrUpdate(
                    c => c.CoursePathId,
                    new CoursePath
                    {
                        CoursePathId = 2,
                        CoursePathName = "Logistics"
                    });

                context.SaveChanges();

                var teacher1 = userManager.FindByName("teacher1@school.com");

                context.Course.AddOrUpdate(
                    c => c.CourseId,
                    new Course
                    {
                        CourseId = 1,
                        CourseName = "Mathematics 1",
                        CoursePathId = 1,
                        TeacherId = teacher1.Id
                    });

                var teacher2 = userManager.FindByName("teacher2@school.com");

                context.Course.AddOrUpdate(
                    c => c.CourseId,
                    new Course
                    {
                        CourseId = 1,
                        CourseName = "Mathematics 2",
                        CoursePathId = 1,
                        TeacherId = teacher1.Id
                    });

                context.SaveChanges();

                //context.Course.AddOrUpdate(
                // c => c.CourseId,
                // new Course
                // {
                //     CourseId = 2,
                //     CourseName = "Mathematics 2",
                //     Teacher = userManager.FindByName("teacher2@school.com")
                // });



                #endregion coursepaths




                //string accountNumber = "ABC123";

                //context.Customers.AddOrUpdate(
                //    c => c.AccountNumber,
                //    new Customer
                //    {
                //        AccountNumber = accountNumber,
                //        CompanyName = "ABC Company of America",
                //        Address = "123 Main St.",
                //        City = "Anytown",
                //        State = "GA",
                //        ZipCode = "30071"
                //    });

                //context.SaveChanges();

                ////lo devo ricaricare per sapere la PK assegnata in automatico
                //Customer customer = context.Customers.First(c => c.AccountNumber == accountNumber);

                //string description = "Just another work order";

                //context.WorkOrders.AddOrUpdate(
                //    wo => wo.Description,
                //    new WorkOrder { Description = description, CustomerId = customer.CustomerId, WorkOrderStatus = WorkOrderStatus.Created }
                //    );

                //context.SaveChanges();

                //WorkOrder workOrder = context.WorkOrders.First(wo => wo.Description == description);

                //context.Parts.AddOrUpdate(
                //    p => p.InventoryItemCode,
                //    new Part { InventoryItemCode = "THING1", InventoryItemName = "Thing Number 1", Quantity = 1, UnitPrice = 1.23m, WorkOrderId = workOrder.WorkOrderId });

                //string categoryName = "Devices";

                //context.Categories.AddOrUpdate(
                //p => p.CategoryName,
                //new Category { CategoryName = categoryName });

                //context.SaveChanges();

                //Category category = context.Categories.First(c => c.CategoryName == categoryName);

                //context.InventoryItems.AddOrUpdate(
                //p => p.InventoryItemCode,
                //new InventoryItem { InventoryItemCode = "THING2", InventoryItemName = "A second kind of thing", UnitPrice = 3.33m, CategoryId = category.Id });


                /////////////Category
                //string categoryName = "Housing";

                //context.Categories.AddOrUpdate(
                //c => c.CategoryName,
                //new Category { CategoryName = categoryName });

                //context.SaveChanges();

                //Category category = context.Categories.First(c => c.CategoryName == categoryName);

                //context.Categories.AddOrUpdate(
                //        c => c.CategoryName,
                //        new Category { CategoryName = "Furniture", ParentCategoryId = category.Id },
                //        new Category { CategoryName = "Fixtures", ParentCategoryId = category.Id },
                //        new Category { CategoryName = "Building Materials", ParentCategoryId = category.Id }
                //        );

                //categoryName = "Learning Materials";

                //context.Categories.AddOrUpdate(
                //    c => c.CategoryName,
                //    new Category { CategoryName = categoryName });

                //context.SaveChanges();

                //category = context.Categories.First(c => c.CategoryName == categoryName);

                //context.Categories.AddOrUpdate(
                //      c => c.CategoryName,
                //      new Category { CategoryName = "Books", ParentCategoryId = category.Id },
                //      new Category { CategoryName = "Supplies", ParentCategoryId = category.Id }

                //      );

                //context.Categories.AddOrUpdate(
                //    c => c.CategoryName,
                //    new Category { CategoryName = "Food and Water" }

                //    );

                //context.SaveChanges();

                //////////////////////////////////

                //category = context.Categories.First(c => c.CategoryName == "Furniture");

                //context.InventoryItems.AddOrUpdate(
                //    ii => ii.InventoryItemName,
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "STUDENTDESK", InventoryItemName = "Student Desk", UnitPrice = 10m },
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "TESCHERDESK", InventoryItemName = "Teacher Desk", UnitPrice = 20m },
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "CHAIR", InventoryItemName = "Chair", UnitPrice = 6.95m }

                //    );

                //category = context.Categories.First(c => c.CategoryName == "Books");

                //context.InventoryItems.AddOrUpdate(
                //    ii => ii.InventoryItemName,
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "SCIENCETEXT", InventoryItemName = "Science Textbook", UnitPrice = 5.99m },
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "ARTTEXT", InventoryItemName = "Art History Textbook", UnitPrice = 6.40m },
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "POETRYTEXT", InventoryItemName = "Greatest Poems", UnitPrice = 3.23m }

                //    );

                //category = context.Categories.First(c => c.CategoryName == "Supplies");

                //context.InventoryItems.AddOrUpdate(
                //    ii => ii.InventoryItemName,
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "STUDENTSOUP", InventoryItemName = "Student Soup", UnitPrice = 3.45m },
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "TECHERSOUP", InventoryItemName = "Teacher Soup", UnitPrice = 4.45m },
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "MYSOUP", InventoryItemName = "My Soup", UnitPrice = 2.45m }

                //    );



                //category = context.Categories.First(c => c.CategoryName == "Housing");

                //context.InventoryItems.AddOrUpdate(
                //    ii => ii.InventoryItemName,
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "CLASSROOM", InventoryItemName = "Pre-fabricated classroom", UnitPrice = 3.45m }

                //    );


                //category = context.Categories.First(c => c.CategoryName == "Fixtures");

                //context.InventoryItems.AddOrUpdate(
                //    ii => ii.InventoryItemName,
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "WHITEBOARD", InventoryItemName = "Whiteboard", UnitPrice = 3.45m },
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "ARMOR", InventoryItemName = "Armor Plating Kit", UnitPrice = 3.45m }

                //    );


                //category = context.Categories.First(c => c.CategoryName == "Building Materials");

                //context.InventoryItems.AddOrUpdate(
                //    ii => ii.InventoryItemName,
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "BUILDING1", InventoryItemName = "Material 1", UnitPrice = 3.45m },
                //    new InventoryItem { CategoryId = category.Id, InventoryItemCode = "BUILDING2", InventoryItemName = "Material 2", UnitPrice = 3.45m }

                //    );

                //context.SaveChanges();


                //context.ServiceItems.AddOrUpdate(
                //   ii => ii.ServiceItemName,
                //   new ServiceItem { ServiceItemCode = "FORMANDOPUR", ServiceItemName = "Form and Pur", Rate = 35.56m },
                //   new ServiceItem { ServiceItemCode = "ERECTPREFS", ServiceItemName = "Prefabbgrifatoi", Rate = 45.56m }


                //   );


                //context.SaveChanges();


                ///////////
                //context.Customers.AddOrUpdate(
                //    cu => cu.AccountNumber,
                //    new Customer { AccountNumber = "GSTEMS", CompanyName = "Girls STEM School", Address = "35 Achievement Way", City = "Detroit", State = "MI", Phone = "123456", ZipCode = "43233" },
                //    new Customer { AccountNumber = "YWLS", CompanyName = "Young Women's Literary Society", Address = "15213 Aruna Lane", City = "Empoli", State = "IT", Phone = "1234565", ZipCode = "00100" },
                //    new Customer { AccountNumber = "TRS", CompanyName = "The Roosvelt School", Address = "731 Krasmer Street", City = "Parigi", State = "FR", Phone = "125555", ZipCode = "50100" }
                //);


                //context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {

                if (System.Diagnostics.Debugger.IsAttached == false)
                    System.Diagnostics.Debugger.Launch();

                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception e)
            {
                if (System.Diagnostics.Debugger.IsAttached == false)
                    System.Diagnostics.Debugger.Launch();
                throw;
            }
        }
    }
}
