namespace QuizApiApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerÁlternetive = c.String(),
                        CorrectAnsswer = c.Boolean(nullable: false),
                        questionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.questionId, cascadeDelete: true)
                .Index(t => t.questionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionTitle = c.String(),
                        Quiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.Quiz_Id)
                .Index(t => t.Quiz_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionAnswereds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnsweredDate = c.DateTime(nullable: false),
                        Answered = c.Boolean(nullable: false),
                        Person_Id = c.Int(),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Quiz_Id", "dbo.Quizs");
            DropForeignKey("dbo.QuestionAnswereds", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.QuestionAnswereds", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Answers", "questionId", "dbo.Questions");
            DropIndex("dbo.QuestionAnswereds", new[] { "Question_Id" });
            DropIndex("dbo.QuestionAnswereds", new[] { "Person_Id" });
            DropIndex("dbo.Questions", new[] { "Quiz_Id" });
            DropIndex("dbo.Answers", new[] { "questionId" });
            DropTable("dbo.Quizs");
            DropTable("dbo.QuestionAnswereds");
            DropTable("dbo.People");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
