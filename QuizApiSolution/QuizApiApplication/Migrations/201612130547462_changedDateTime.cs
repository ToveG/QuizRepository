namespace QuizApiApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AnswerRegisters", "AnsweredDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AnswerRegisters", "AnsweredDate", c => c.DateTime(nullable: false));
        }
    }
}
