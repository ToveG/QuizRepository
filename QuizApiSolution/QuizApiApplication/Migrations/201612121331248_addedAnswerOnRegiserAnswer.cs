namespace QuizApiApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAnswerOnRegiserAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnswerRegisters", "Answer_Id", c => c.Int());
            CreateIndex("dbo.AnswerRegisters", "Answer_Id");
            AddForeignKey("dbo.AnswerRegisters", "Answer_Id", "dbo.Answers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnswerRegisters", "Answer_Id", "dbo.Answers");
            DropIndex("dbo.AnswerRegisters", new[] { "Answer_Id" });
            DropColumn("dbo.AnswerRegisters", "Answer_Id");
        }
    }
}
