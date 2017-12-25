namespace SchoolADM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 250, fixedLength: true),
                        CoursePathId = c.Int(nullable: false),
                        Teacher_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.CoursePaths", t => t.CoursePathId)
                .ForeignKey("dbo.AspNetUsers", t => t.Teacher_Id)
                .Index(t => t.CoursePathId)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.CoursePaths",
                c => new
                    {
                        CoursePathId = c.Int(nullable: false, identity: true),
                        CoursePathName = c.String(nullable: false, maxLength: 250, fixedLength: true),
                    })
                .PrimaryKey(t => t.CoursePathId)
                .Index(t => t.CoursePathName, unique: true, name: "AK_CoursePath_CoursePathName");
            
            CreateTable(
                "dbo.EnrolledClasses",
                c => new
                    {
                        EnrolledClassId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        ExamDate = c.DateTime(nullable: false),
                        ExamGrade = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Student_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EnrolledClassId)
                .ForeignKey("dbo.AspNetUsers", t => t.Student_Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Teacher_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.EnrolledClasses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.EnrolledClasses", "Student_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "CoursePathId", "dbo.CoursePaths");
            DropIndex("dbo.EnrolledClasses", new[] { "Student_Id" });
            DropIndex("dbo.EnrolledClasses", new[] { "CourseId" });
            DropIndex("dbo.CoursePaths", "AK_CoursePath_CoursePathName");
            DropIndex("dbo.Courses", new[] { "Teacher_Id" });
            DropIndex("dbo.Courses", new[] { "CoursePathId" });
            DropTable("dbo.EnrolledClasses");
            DropTable("dbo.CoursePaths");
            DropTable("dbo.Courses");
        }
    }
}
