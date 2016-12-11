namespace QuizApiApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Quiz_Id", "dbo.Quizs");
            DropIndex("dbo.Questions", new[] { "Quiz_Id" });
            RenameColumn(table: "dbo.Questions", name: "Quiz_Id", newName: "quizId");
            AddColumn("dbo.Answers", "AnswerAlternetive", c => c.String());
            AddColumn("dbo.Answers", "CorrectAnswer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Quizs", "totalAmountOfQuestions", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "quizId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "quizId");
            AddForeignKey("dbo.Questions", "quizId", "dbo.Quizs", "Id", cascadeDelete: true);
            DropColumn("dbo.Answers", "AnswerÁlternetive");
            DropColumn("dbo.Answers", "CorrectAnsswer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "CorrectAnsswer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Answers", "AnswerÁlternetive", c => c.String());
            DropForeignKey("dbo.Questions", "quizId", "dbo.Quizs");
            DropIndex("dbo.Questions", new[] { "quizId" });
            AlterColumn("dbo.Questions", "quizId", c => c.Int());
            DropColumn("dbo.Quizs", "totalAmountOfQuestions");
            DropColumn("dbo.Answers", "CorrectAnswer");
            DropColumn("dbo.Answers", "AnswerAlternetive");
            RenameColumn(table: "dbo.Questions", name: "quizId", newName: "Quiz_Id");
            CreateIndex("dbo.Questions", "Quiz_Id");
            AddForeignKey("dbo.Questions", "Quiz_Id", "dbo.Quizs", "Id");
        }
    }
}
