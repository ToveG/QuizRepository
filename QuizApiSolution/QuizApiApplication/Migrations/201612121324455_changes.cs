namespace QuizApiApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.QuestionAnswereds", newName: "AnswerRegisters");
            AddColumn("dbo.AnswerRegisters", "Quiz_Id", c => c.Int());
            CreateIndex("dbo.AnswerRegisters", "Quiz_Id");
            AddForeignKey("dbo.AnswerRegisters", "Quiz_Id", "dbo.Quizs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnswerRegisters", "Quiz_Id", "dbo.Quizs");
            DropIndex("dbo.AnswerRegisters", new[] { "Quiz_Id" });
            DropColumn("dbo.AnswerRegisters", "Quiz_Id");
            RenameTable(name: "dbo.AnswerRegisters", newName: "QuestionAnswereds");
        }
    }
}
