using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace be.Models;

public partial class SwtContext : DbContext
{
    public SwtContext()
    {
    }

    public SwtContext(DbContextOptions<SwtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Combination> Combinations { get; set; }

    public virtual DbSet<Coursechapter> Coursechapters { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Groupsubject> Groupsubjects { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Newcategory> Newcategorys { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Postcomment> Postcomments { get; set; }

    public virtual DbSet<Postfavourite> Postfavourites { get; set; }

    public virtual DbSet<Postlike> Postlikes { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Questiontest> Questiontests { get; set; }

    public virtual DbSet<Reportpost> Reportposts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Testdetail> Testdetails { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=db8169.public.databaseasp.net; Database=db8169; User Id=db8169; Password=qF_3B5j=8#Zh; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__ACCOUNT__349DA5A667ADBB75");

            entity.ToTable("ACCOUNT");

            entity.Property(e => e.Avatar).IsUnicode(false);
            entity.Property(e => e.BirthDay).HasColumnType("datetime");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SchoolName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__ACCOUNT__RoleId__4AB81AF0");
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK__ANSWERS__D4825004CEB02033");

            entity.ToTable("ANSWERS");

            entity.Property(e => e.AnswerName).HasMaxLength(200);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<Combination>(entity =>
        {
            entity.HasKey(e => e.CombinationId).HasName("PK__COMBINAT__D188AC02D5ACE372");

            entity.ToTable("COMBINATIONS");

            entity.Property(e => e.CombinationName).HasMaxLength(300);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.MajorName).HasMaxLength(300);
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.School).WithMany(p => p.Combinations)
                .HasForeignKey(d => d.SchoolId)
                .HasConstraintName("FK__COMBINATI__Schoo__4BAC3F29");
        });

        modelBuilder.Entity<Coursechapter>(entity =>
        {
            entity.HasKey(e => e.ChapterId).HasName("PK_CourseChapter");

            entity.ToTable("COURSECHAPTER");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");

            entity.HasOne(d => d.Grade).WithMany(p => p.Coursechapters)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_COURSECHAPTER_GRADES");

            entity.HasOne(d => d.Subjec).WithMany(p => p.Coursechapters)
                .HasForeignKey(d => d.SubjecId)
                .HasConstraintName("FK_CourseChapter_SUBJECTS");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.ToTable("GRADES");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<Groupsubject>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GROUPSUBJECTS");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Combination).WithMany()
                .HasForeignKey(d => d.CombinationId)
                .HasConstraintName("FK__GROUPSUBJ__Combi__4E88ABD4");

            entity.HasOne(d => d.Subject).WithMany()
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__GROUPSUBJ__Subje__4F7CD00D");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PK__LEVELS__09F03C263D4D213A");

            entity.ToTable("LEVELS");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.LevelName).HasMaxLength(200);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<Newcategory>(entity =>
        {
            entity.HasKey(e => e.NewCategoryId).HasName("PK__NEWCATEG__84E7EAB32FEA1411");

            entity.ToTable("NEWCATEGORYS");

            entity.Property(e => e.CategoryName).HasMaxLength(200);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewId).HasName("PK__NEWS__7CC3777E07A4CF30");

            entity.ToTable("NEWS");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Account).WithMany(p => p.News)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__NEWS__AccountId__5070F446");

            entity.HasOne(d => d.NewCategory).WithMany(p => p.News)
                .HasForeignKey(d => d.NewCategoryId)
                .HasConstraintName("FK__NEWS__NewCategor__5165187F");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__POSTS__AA126018296B7CD9");

            entity.ToTable("POSTS");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.PostFile).HasMaxLength(500);
            entity.Property(e => e.PostText).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Posts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__POSTS__AccountId__5812160E");

            entity.HasOne(d => d.Subject).WithMany(p => p.Posts)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__POSTS__SubjectId__59063A47");
        });

        modelBuilder.Entity<Postcomment>(entity =>
        {
            entity.HasKey(e => e.PostCommentId).HasName("PK__POSTCOMM__A955AFEDC74045E6");

            entity.ToTable("POSTCOMMENTS");

            entity.Property(e => e.CommentDate).HasColumnType("datetime");
            entity.Property(e => e.Content).HasMaxLength(500);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.FileComment).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Postcomments)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__POSTCOMME__Accou__52593CB8");

            entity.HasOne(d => d.Post).WithMany(p => p.Postcomments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__POSTCOMME__PostI__534D60F1");
        });

        modelBuilder.Entity<Postfavourite>(entity =>
        {
            entity.HasKey(e => e.PostFavouriteId).HasName("PK__POSTFAVO__91F6FB97F1AB4DD7");

            entity.ToTable("POSTFAVOURITES");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Postfavourites)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__POSTFAVOU__Accou__5441852A");

            entity.HasOne(d => d.Post).WithMany(p => p.Postfavourites)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__POSTFAVOU__PostI__5535A963");
        });

        modelBuilder.Entity<Postlike>(entity =>
        {
            entity.HasKey(e => e.PostLikeId).HasName("PK__POSTLIKE__4CF65C19035C95E9");

            entity.ToTable("POSTLIKES");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.LikeDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Postlikes)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__POSTLIKES__Accou__5629CD9C");

            entity.HasOne(d => d.Post).WithMany(p => p.Postlikes)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__POSTLIKES__PostI__571DF1D5");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__QUESTION__0DC06FAC6EBAAE73");

            entity.ToTable("QUESTIONS");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.QuestionContext).HasMaxLength(300);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Questions)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__QUESTIONS__Accou__59FA5E80");

            entity.HasOne(d => d.Answer).WithMany(p => p.Questions)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK__QUESTIONS__Answe__5AEE82B9");

            entity.HasOne(d => d.CourseChapter).WithMany(p => p.Questions)
                .HasForeignKey(d => d.CourseChapterId)
                .HasConstraintName("FK_QUESTIONS_CourseChapter");

            entity.HasOne(d => d.Level).WithMany(p => p.Questions)
                .HasForeignKey(d => d.LevelId)
                .HasConstraintName("FK__QUESTIONS__Level__5BE2A6F2");

            entity.HasOne(d => d.Topic).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__QUESTIONS__Topic__5CD6CB2B");
        });

        modelBuilder.Entity<Questiontest>(entity =>
        {
            entity.HasKey(e => e.TestId).HasName("PK__QUESTION__8CC33160F5C7E11F");

            entity.ToTable("QUESTIONTESTS");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TestDetailId).HasColumnName("TestDetailID");

            entity.HasOne(d => d.Answer).WithMany(p => p.Questiontests)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK__QUESTIONT__Answe__5EBF139D");

            entity.HasOne(d => d.Question).WithMany(p => p.Questiontests)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__QUESTIONT__Quest__5FB337D6");

            entity.HasOne(d => d.TestDetail).WithMany(p => p.Questiontests)
                .HasForeignKey(d => d.TestDetailId)
                .HasConstraintName("FK__QUESTIONT__TestD__60A75C0F");
        });

        modelBuilder.Entity<Reportpost>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__REPORTPO__D5BD48055C7CEA36");

            entity.ToTable("REPORTPOSTS");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Reportposts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__REPORTPOS__Accou__619B8048");

            entity.HasOne(d => d.Post).WithMany(p => p.Reportposts)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__REPORTPOS__PostI__628FA481");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__ROLE__8AFACE1A4A2CB5FC");

            entity.ToTable("ROLE");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.RoleName).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.SchoolId).HasName("PK__SCHOOLS__3DA4675B8114F3D1");

            entity.ToTable("SCHOOLS");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.SchoolName).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__SUBJECTS__AC1BA3A83061DEF3");

            entity.ToTable("SUBJECTS");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.ImgLink)
                .IsUnicode(false)
                .HasColumnName("imgLink");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SubjectName).HasMaxLength(50);
        });

        modelBuilder.Entity<Testdetail>(entity =>
        {
            entity.HasKey(e => e.TestDetailId).HasName("PK__TESTDETA__F5085946A14CB6BA");

            entity.ToTable("TESTDETAILS");

            entity.Property(e => e.TestDetailId).HasColumnName("TestDetailID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__TOPICS__022E0F5DD0BF616D");

            entity.ToTable("TOPICS");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Duration).HasMaxLength(200);
            entity.Property(e => e.FinishTestDate).HasColumnType("datetime");
            entity.Property(e => e.StartTestDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TopicName).HasMaxLength(200);

            entity.HasOne(d => d.Subject).WithMany(p => p.Topics)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_TOPICS_SUBJECTS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
