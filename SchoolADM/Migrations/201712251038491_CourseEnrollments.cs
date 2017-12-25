namespace SchoolADM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseEnrollments : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Courses", new[] { "Teacher_Id" });
            RenameColumn(table: "dbo.Courses", name: "Teacher_Id", newName: "TeacherId");
            RenameColumn(table: "dbo.EnrolledClasses", name: "Student_Id", newName: "StudentId");
            RenameIndex(table: "dbo.EnrolledClasses", name: "IX_Student_Id", newName: "IX_StudentId");
            AlterColumn("dbo.Courses", "TeacherId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Courses", "TeacherId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            AlterColumn("dbo.Courses", "TeacherId", c => c.String(maxLength: 128));
            RenameIndex(table: "dbo.EnrolledClasses", name: "IX_StudentId", newName: "IX_Student_Id");
            RenameColumn(table: "dbo.EnrolledClasses", name: "StudentId", newName: "Student_Id");
            RenameColumn(table: "dbo.Courses", name: "TeacherId", newName: "Teacher_Id");
            CreateIndex("dbo.Courses", "Teacher_Id");
        }
    }
}
