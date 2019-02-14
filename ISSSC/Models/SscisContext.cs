using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISSSC.Models
{
    public partial class SscisContext : DbContext
    {
        public SscisContext()
        {
        }

        public SscisContext(DbContextOptions<SscisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Approval> Approval { get; set; }
        public virtual DbSet<EnumRole> EnumRole { get; set; }
        public virtual DbSet<EnumSubject> EnumSubject { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Participation> Participation { get; set; }
        public virtual DbSet<SscisContent> SscisContent { get; set; }
        public virtual DbSet<SscisParam> SscisParam { get; set; }
        public virtual DbSet<SscisSession> SscisSession { get; set; }
        public virtual DbSet<SscisUser> SscisUser { get; set; }
        public virtual DbSet<TutorApplication> TutorApplication { get; set; }
        public virtual DbSet<TutorApplicationSubject> TutorApplicationSubject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;database=sscis");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Approval>(entity =>
            {
                entity.ToTable("approval", "sscis");

                entity.HasIndex(e => e.IdSubject)
                    .HasName("ID_SUBJECT")
                    .IsUnique();

                entity.HasIndex(e => e.IdTutor)
                    .HasName("ID_TUTOR")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSubject)
                    .HasColumnName("ID_SUBJECT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTutor)
                    .HasColumnName("ID_TUTOR")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithOne(p => p.Approval)
                    .HasForeignKey<Approval>(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("approval_ibfk_2");

                entity.HasOne(d => d.IdTutorNavigation)
                    .WithOne(p => p.Approval)
                    .HasForeignKey<Approval>(d => d.IdTutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("approval_ibfk_1");
            });

            modelBuilder.Entity<EnumRole>(entity =>
            {
                entity.ToTable("enum_role", "sscis");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("ROLE")
                    .HasMaxLength(24)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumSubject>(entity =>
            {
                entity.ToTable("enum_subject", "sscis");

                entity.HasIndex(e => e.IdParent)
                    .HasName("ID_PARENT")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdParent)
                    .HasColumnName("ID_PARENT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lesson)
                    .HasColumnName("LESSON")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParentNavigation)
                    .WithOne(p => p.InverseIdParentNavigation)
                    .HasForeignKey<EnumSubject>(d => d.IdParent)
                    .HasConstraintName("enum_subject_ibfk_1");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event", "sscis");

                entity.HasIndex(e => e.IdSubject)
                    .HasName("ID_SUBJECT")
                    .IsUnique();

                entity.HasIndex(e => e.IdTutor)
                    .HasName("ID_TUTOR")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CancelationComment)
                    .IsRequired()
                    .HasColumnName("CANCELATION_COMMENT")
                    .HasMaxLength(480)
                    .IsUnicode(false);

                entity.Property(e => e.IdSubject)
                    .HasColumnName("ID_SUBJECT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTutor)
                    .HasColumnName("ID_TUTOR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsAccepted)
                    .HasColumnName("IS_ACCEPTED")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsCancelled)
                    .HasColumnName("IS_CANCELLED")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsExtraLesson)
                    .HasColumnName("IS_EXTRA_LESSON")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.TimeFrom).HasColumnName("TIME_FROM");

                entity.Property(e => e.TimeTo).HasColumnName("TIME_TO");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithOne(p => p.Event)
                    .HasForeignKey<Event>(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_ibfk_1");

                entity.HasOne(d => d.IdTutorNavigation)
                    .WithOne(p => p.Event)
                    .HasForeignKey<Event>(d => d.IdTutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_ibfk_2");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback", "sscis");

                entity.HasIndex(e => e.IdParticipation)
                    .HasName("ID_PARTICIPATION")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdParticipation)
                    .HasColumnName("ID_PARTICIPATION")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("TEXT")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParticipationNavigation)
                    .WithOne(p => p.Feedback)
                    .HasForeignKey<Feedback>(d => d.IdParticipation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("feedback_ibfk_1");
            });

            modelBuilder.Entity<Participation>(entity =>
            {
                entity.ToTable("participation", "sscis");

                entity.HasIndex(e => e.IdEvent)
                    .HasName("ID_EVENT")
                    .IsUnique();

                entity.HasIndex(e => e.IdUser)
                    .HasName("ID_USER")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEvent)
                    .HasColumnName("ID_EVENT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUser)
                    .HasColumnName("ID_USER")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithOne(p => p.Participation)
                    .HasForeignKey<Participation>(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("participation_ibfk_1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Participation)
                    .HasForeignKey<Participation>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("participation_ibfk_2");
            });

            modelBuilder.Entity<SscisContent>(entity =>
            {
                entity.ToTable("sscis_content", "sscis");

                entity.HasIndex(e => e.IdAuthor)
                    .HasName("ID_AUTHOR")
                    .IsUnique();

                entity.HasIndex(e => e.IdEditedBy)
                    .HasName("ID_EDITED_BY")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created).HasColumnName("CREATED");

                entity.Property(e => e.Edited).HasColumnName("EDITED");

                entity.Property(e => e.Header)
                    .IsRequired()
                    .HasColumnName("HEADER")
                    .HasMaxLength(180)
                    .IsUnicode(false);

                entity.Property(e => e.IdAuthor)
                    .HasColumnName("ID_AUTHOR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEditedBy)
                    .HasColumnName("ID_EDITED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TextContent)
                    .IsRequired()
                    .HasColumnName("TEXT_CONTENT")
                    .HasMaxLength(3200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithOne(p => p.SscisContentIdAuthorNavigation)
                    .HasForeignKey<SscisContent>(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sscis_content_ibfk_1");

                entity.HasOne(d => d.IdEditedByNavigation)
                    .WithOne(p => p.SscisContentIdEditedByNavigation)
                    .HasForeignKey<SscisContent>(d => d.IdEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sscis_content_ibfk_2");
            });

            modelBuilder.Entity<SscisParam>(entity =>
            {
                entity.ToTable("sscis_param", "sscis");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(480)
                    .IsUnicode(false);

                entity.Property(e => e.ParamKey)
                    .IsRequired()
                    .HasColumnName("PARAM_KEY")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.ParamValue)
                    .IsRequired()
                    .HasColumnName("PARAM_VALUE")
                    .HasMaxLength(240)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SscisSession>(entity =>
            {
                entity.ToTable("sscis_session", "sscis");

                entity.HasIndex(e => e.IdUser)
                    .HasName("ID_USER")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Expiration).HasColumnName("EXPIRATION");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasColumnName("HASH")
                    .HasMaxLength(480)
                    .IsUnicode(false);

                entity.Property(e => e.IdUser)
                    .HasColumnName("ID_USER")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SessionStart).HasColumnName("SESSION_START");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.SscisSession)
                    .HasForeignKey<SscisSession>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sscis_session_ibfk_1");
            });

            modelBuilder.Entity<SscisUser>(entity =>
            {
                entity.ToTable("sscis_user", "sscis");

                entity.HasIndex(e => e.IdRole)
                    .HasName("ID_ROLE")
                    .IsUnique();

                entity.HasIndex(e => e.IsActivatedBy)
                    .HasName("IS_ACTIVATED_BY")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Activated).HasColumnName("ACTIVATED");

                entity.Property(e => e.Created).HasColumnName("CREATED");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdRole)
                    .HasColumnName("ID_ROLE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsActivatedBy)
                    .HasColumnName("IS_ACTIVATED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("LOGIN")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.StudentNumber)
                    .IsRequired()
                    .HasColumnName("STUDENT_NUMBER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithOne(p => p.SscisUser)
                    .HasForeignKey<SscisUser>(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sscis_user_ibfk_2");

                entity.HasOne(d => d.IsActivatedByNavigation)
                    .WithOne(p => p.InverseIsActivatedByNavigation)
                    .HasForeignKey<SscisUser>(d => d.IsActivatedBy)
                    .HasConstraintName("sscis_user_ibfk_1");
            });

            modelBuilder.Entity<TutorApplication>(entity =>
            {
                entity.ToTable("tutor_application", "sscis");

                entity.HasIndex(e => e.AcceptedById)
                    .HasName("ACCEPTED_BY_ID")
                    .IsUnique();

                entity.HasIndex(e => e.IdUser)
                    .HasName("ID_USER")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcceptedById)
                    .HasColumnName("ACCEPTED_BY_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcceptedDate).HasColumnName("ACCEPTED_DATE");

                entity.Property(e => e.ApplicationDate).HasColumnName("APPLICATION_DATE");

                entity.Property(e => e.IdUser)
                    .HasColumnName("ID_USER")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsAccepted)
                    .HasColumnName("IS_ACCEPTED")
                    .HasColumnType("tinyint(1)");

                entity.HasOne(d => d.AcceptedBy)
                    .WithOne(p => p.TutorApplicationAcceptedBy)
                    .HasForeignKey<TutorApplication>(d => d.AcceptedById)
                    .HasConstraintName("tutor_application_ibfk_2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.TutorApplicationIdUserNavigation)
                    .HasForeignKey<TutorApplication>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tutor_application_ibfk_1");
            });

            modelBuilder.Entity<TutorApplicationSubject>(entity =>
            {
                entity.ToTable("tutor_application_subject", "sscis");

                entity.HasIndex(e => e.IdApplication)
                    .HasName("ID_APPLICATION")
                    .IsUnique();

                entity.HasIndex(e => e.IdSubject)
                    .HasName("ID_SUBJECT")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Degree)
                    .HasColumnName("DEGREE")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IdApplication)
                    .HasColumnName("ID_APPLICATION")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSubject)
                    .HasColumnName("ID_SUBJECT")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdApplicationNavigation)
                    .WithOne(p => p.TutorApplicationSubject)
                    .HasForeignKey<TutorApplicationSubject>(d => d.IdApplication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tutor_application_subject_ibfk_1");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithOne(p => p.TutorApplicationSubject)
                    .HasForeignKey<TutorApplicationSubject>(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tutor_application_subject_ibfk_2");
            });
        }
    }
}
