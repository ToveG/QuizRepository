namespace QuizApiApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixesInAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "AnswerAlternative", c => c.String());
            DropColumn("dbo.Answers", "AnswerAlternetive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "AnswerAlternetive", c => c.String());
            DropColumn("dbo.Answers", "AnswerAlternative");
        }
    }
}
