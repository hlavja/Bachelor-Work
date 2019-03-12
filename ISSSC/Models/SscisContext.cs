//using System;
//using System.Configuration;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.Extensions.Configuration;

//TODO Localhost database usage

//namespace ISSSC.Models
//{
//    public partial class SscisContext : DbContext
//    {
//        public SscisContext()
//        {
//        }

//        public SscisContext(DbContextOptions<SscisContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Approval> Approval { get; set; }
//        public virtual DbSet<EnumRole> EnumRole { get; set; }
//        public virtual DbSet<EnumSubject> EnumSubject { get; set; }
//        public virtual DbSet<Event> Event { get; set; }
//        public virtual DbSet<Feedback> Feedback { get; set; }
//        public virtual DbSet<Participation> Participation { get; set; }
//        public virtual DbSet<SscisContent> SscisContent { get; set; }
//        public virtual DbSet<SscisParam> SscisParam { get; set; }
//        public virtual DbSet<SscisSession> SscisSession { get; set; }
//        public virtual DbSet<SscisUser> SscisUser { get; set; }
//        public virtual DbSet<TutorApplication> TutorApplication { get; set; }
//        public virtual DbSet<TutorApplicationSubject> TutorApplicationSubject { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                IConfigurationRoot configuration = new ConfigurationBuilder()
//                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//                    .AddJsonFile("appsettings.json")
//                    .Build();
//                optionsBuilder.UseLazyLoadingProxies().UseMySQL(configuration.GetConnectionString("Localhost"));
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

//            modelBuilder.Entity<Approval>(entity =>
//            {
//                entity.ToTable("approval", "sscis");

//                entity.HasIndex(e => e.IdSubject)
//                    .HasName("ID_SUBJECT");

//                entity.HasIndex(e => e.IdTutor)
//                    .HasName("ID_TUTOR");

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IdSubject)
//                    .HasColumnName("ID_SUBJECT")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IdTutor)
//                    .HasColumnName("ID_TUTOR")
//                    .HasColumnType("int(11)");

//                entity.HasOne(d => d.IdSubjectNavigation)
//                    .WithMany(p => p.Approval)
//                    .HasForeignKey(d => d.IdSubject)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("approval_ibfk_2");

//                entity.HasOne(d => d.IdTutorNavigation)
//                    .WithMany(p => p.Approval)
//                    .HasForeignKey(d => d.IdTutor)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("approval_ibfk_1");
//            });

//            modelBuilder.Entity<EnumRole>(entity =>
//            {
//                entity.ToTable("enum_role", "sscis");

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.Description)
//                    .IsRequired()
//                    .HasColumnName("DESCRIPTION")
//                    .HasMaxLength(160)
//                    .IsUnicode(false);

//                entity.Property(e => e.Role)
//                    .IsRequired()
//                    .HasColumnName("ROLE")
//                    .HasMaxLength(24)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<EnumSubject>(entity =>
//            {
//                entity.ToTable("enum_subject", "sscis");

//                entity.HasIndex(e => e.IdParent)
//                    .HasName("ID_PARENT");

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.Code)
//                    .IsRequired()
//                    .HasColumnName("CODE")
//                    .HasMaxLength(10)
//                    .IsUnicode(false);

//                entity.Property(e => e.IdParent)
//                    .HasColumnName("ID_PARENT")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.Lesson)
//                    .HasColumnName("LESSON")
//                    .HasColumnType("tinyint(1)");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasColumnName("NAME")
//                    .HasMaxLength(30)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.IdParentNavigation)
//                    .WithMany(p => p.InverseIdParentNavigation)
//                    .HasForeignKey(d => d.IdParent)
//                    .HasConstraintName("enum_subject_ibfk_1");
//            });

//            modelBuilder.Entity<Event>(entity =>
//            {
//                entity.ToTable("event", "sscis");

//                entity.HasIndex(e => e.IdApplicant)
//                    .HasName("ID_APPLICANT");

//                entity.HasIndex(e => e.IdSubject)
//                    .HasName("ID_SUBJECT");

//                entity.HasIndex(e => e.IdTutor)
//                    .HasName("ID_TUTOR");

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.Attendance)
//                    .HasColumnName("ATTENDANCE")
//                    .HasColumnType("int(50)");

//                entity.Property(e => e.CancelationComment)
//                    .HasColumnName("CANCELATION_COMMENT")
//                    .HasMaxLength(480)
//                    .IsUnicode(false);

//                entity.Property(e => e.IdApplicant)
//                    .HasColumnName("ID_APPLICANT")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IdSubject)
//                    .HasColumnName("ID_SUBJECT")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IdTutor)
//                    .HasColumnName("ID_TUTOR")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IsAccepted)
//                    .HasColumnName("IS_ACCEPTED")
//                    .HasColumnType("tinyint(1)");

//                entity.Property(e => e.IsCancelled)
//                    .HasColumnName("IS_CANCELLED")
//                    .HasColumnType("tinyint(1)");

//                entity.Property(e => e.IsExtraLesson)
//                    .HasColumnName("IS_EXTRA_LESSON")
//                    .HasColumnType("tinyint(1)");

//                entity.Property(e => e.TimeFrom).HasColumnName("TIME_FROM");

//                entity.Property(e => e.TimeTo).HasColumnName("TIME_TO");

//                entity.HasOne(d => d.IdApplicantNavigation)
//                    .WithMany(p => p.EventIdApplicantNavigation)
//                    .HasForeignKey(d => d.IdApplicant)
//                    .HasConstraintName("event_ibfk_3");

//                entity.HasOne(d => d.IdSubjectNavigation)
//                    .WithMany(p => p.Event)
//                    .HasForeignKey(d => d.IdSubject)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("event_ibfk_1");

//                entity.HasOne(d => d.IdTutorNavigation)
//                    .WithMany(p => p.EventIdTutorNavigation)
//                    .HasForeignKey(d => d.IdTutor)
//                    .HasConstraintName("event_ibfk_2");
//            });

//            modelBuilder.Entity<Feedback>(entity =>
//            {
//                entity.ToTable("feedback", "sscis");

//                entity.HasIndex(e => e.IdParticipation)
//                    .HasName("ID_PARTICIPATION");

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IdParticipation)
//                    .HasColumnName("ID_PARTICIPATION")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.Text)
//                    .IsRequired()
//                    .HasColumnName("TEXT")
//                    .HasMaxLength(1000)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.IdParticipationNavigation)
//                    .WithMany(p => p.Feedback)
//                    .HasForeignKey(d => d.IdParticipation)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("feedback_ibfk_1");
//            });

//            modelBuilder.Entity<Participation>(entity =>
//            {
//                entity.ToTable("participation", "sscis");

//                entity.HasIndex(e => e.IdEvent)
//                    .HasName("ID_EVENT");

//                entity.HasIndex(e => e.IdUser)
//                    .HasName("ID_USER");

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IdEvent)
//                    .HasColumnName("ID_EVENT")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IdUser)
//                    .HasColumnName("ID_USER")
//                    .HasColumnType("int(11)");

//                entity.HasOne(d => d.IdEventNavigation)
//                    .WithMany(p => p.Participation)
//                    .HasForeignKey(d => d.IdEvent)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("participation_ibfk_1");

//                entity.HasOne(d => d.IdUserNavigation)
//                    .WithMany(p => p.Participation)
//                    .HasForeignKey(d => d.IdUser)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("participation_ibfk_2");
//            });

//            modelBuilder.Entity<SscisContent>(entity =>
//            {
//                entity.ToTable("sscis_content", "sscis");

//                entity.HasIndex(e => e.IdAuthor)
//                    .HasName("ID_AUTHOR");

//                entity.HasIndex(e => e.IdEditedBy)
//                    .HasName("ID_EDITED_BY");

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.Created).HasColumnName("CREATED");

//                entity.Property(e => e.Edited).HasColumnName("EDITED");

//                entity.Property(e => e.Header)
//                    .IsRequired()
//                    .HasColumnName("HEADER")
//                    .HasMaxLength(180)
//                    .IsUnicode(false);

//                entity.Property(e => e.IdAuthor)
//                    .HasColumnName("ID_AUTHOR")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IdEditedBy)
//                    .HasColumnName("ID_EDITED_BY")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.TextContent)
//                    .IsRequired()
//                    .HasColumnName("TEXT_CONTENT")
//                    .HasMaxLength(3200)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.IdAuthorNavigation)
//                    .WithMany(p => p.SscisContentIdAuthorNavigation)
//                    .HasForeignKey(d => d.IdAuthor)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("sscis_content_ibfk_1");

//                entity.HasOne(d => d.IdEditedByNavigation)
//                    .WithMany(p => p.SscisContentIdEditedByNavigation)
//                    .HasForeignKey(d => d.IdEditedBy)
//                    .HasConstraintName("sscis_content_ibfk_2");
//            });

//            modelBuilder.Entity<SscisParam>(entity =>
//            {
//                entity.ToTable("sscis_param", "sscis");

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.Description)
//                    .IsRequired()
//                    .HasColumnName("DESCRIPTION")
//                    .HasMaxLength(480)
//                    .IsUnicode(false);

//                entity.Property(e => e.ParamKey)
//                    .IsRequired()
//                    .HasColumnName("PARAM_KEY")
//                    .HasMaxLength(120)
//                    .IsUnicode(false);

//                entity.Property(e => e.ParamValue)
//                    .IsRequired()
//                    .HasColumnName("PARAM_VALUE")
//                    .HasMaxLength(240)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<SscisSession>(entity =>
//            {
//                entity.ToTable("sscis_session", "sscis");

//                entity.HasIndex(e => e.IdUser)
//                    .HasName("ID_USER");

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.Expiration).HasColumnName("EXPIRATION");

//                entity.Property(e => e.Hash)
//                    .IsRequired()
//                    .HasColumnName("HASH")
//                    .HasMaxLength(480)
//                    .IsUnicode(false);

//                entity.Property(e => e.IdUser)
//                    .HasColumnName("ID_USER")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.SessionStart).HasColumnName("SESSION_START");

//                entity.HasOne(d => d.IdUserNavigation)
//                    .WithMany(p => p.SscisSession)
//                    .HasForeignKey(d => d.IdUser)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("sscis_session_ibfk_1");
//            });

//            modelBuilder.Entity<SscisUser>(entity =>
//            {
//                entity.ToTable("sscis_user", "sscis");

//                entity.HasIndex(e => e.IdRole)
//                    .HasName("ID_ROLE");

//                entity.HasIndex(e => e.IsActivatedBy)
//                    .HasName("IS_ACTIVATED_BY");

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.Activated).HasColumnName("ACTIVATED");

//                entity.Property(e => e.Created).HasColumnName("CREATED");

//                entity.Property(e => e.Email)
//                    .HasColumnName("EMAIL")
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.Firstname)
//                    .IsRequired()
//                    .HasColumnName("FIRSTNAME")
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.IdRole)
//                    .HasColumnName("ID_ROLE")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IsActivatedBy)
//                    .HasColumnName("IS_ACTIVATED_BY")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IsActive)
//                    .HasColumnName("IS_ACTIVE")
//                    .HasColumnType("tinyint(1)");

//                entity.Property(e => e.Lastname)
//                    .IsRequired()
//                    .HasColumnName("LASTNAME")
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.Login)
//                    .IsRequired()
//                    .HasColumnName("LOGIN")
//                    .HasMaxLength(160)
//                    .IsUnicode(false);

//                entity.Property(e => e.StudentNumber)
//                    .HasColumnName("STUDENT_NUMBER")
//                    .HasMaxLength(10)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.IdRoleNavigation)
//                    .WithMany(p => p.SscisUser)
//                    .HasForeignKey(d => d.IdRole)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("sscis_user_ibfk_2");

//                entity.HasOne(d => d.IsActivatedByNavigation)
//                    .WithMany(p => p.InverseIsActivatedByNavigation)
//                    .HasForeignKey(d => d.IsActivatedBy)
//                    .HasConstraintName("sscis_user_ibfk_1");
//            });

//            modelBuilder.Entity<TutorApplication>(entity =>
//            {
//                entity.ToTable("tutor_application", "sscis");

//                entity.HasIndex(e => e.AcceptedById)
//                    .HasName("ACCEPTED_BY_ID");

//                entity.HasIndex(e => e.IdUser)
//                    .HasName("ID_USER");

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.AcceptedById)
//                    .HasColumnName("ACCEPTED_BY_ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.AcceptedDate).HasColumnName("ACCEPTED_DATE");

//                entity.Property(e => e.ApplicationDate).HasColumnName("APPLICATION_DATE");

//                entity.Property(e => e.IdUser)
//                    .HasColumnName("ID_USER")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IsAccepted)
//                    .HasColumnName("IS_ACCEPTED")
//                    .HasColumnType("tinyint(1)");

//                entity.HasOne(d => d.AcceptedBy)
//                    .WithMany(p => p.TutorApplicationAcceptedBy)
//                    .HasForeignKey(d => d.AcceptedById)
//                    .HasConstraintName("tutor_application_ibfk_2");

//                entity.HasOne(d => d.IdUserNavigation)
//                    .WithMany(p => p.TutorApplicationIdUserNavigation)
//                    .HasForeignKey(d => d.IdUser)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("tutor_application_ibfk_1");
//            });

//            modelBuilder.Entity<TutorApplicationSubject>(entity =>
//            {
//                entity.ToTable("tutor_application_subject", "sscis");

//                entity.HasIndex(e => e.IdApplication)
//                    .HasName("ID_APPLICATION");

//                entity.HasIndex(e => e.IdSubject)
//                    .HasName("ID_SUBJECT");

//                entity.Property(e => e.Id)
//                    .HasColumnName("ID")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.Degree)
//                    .HasColumnName("DEGREE")
//                    .HasColumnType("tinyint(1)");

//                entity.Property(e => e.IdApplication)
//                    .HasColumnName("ID_APPLICATION")
//                    .HasColumnType("int(11)");

//                entity.Property(e => e.IdSubject)
//                    .HasColumnName("ID_SUBJECT")
//                    .HasColumnType("int(11)");

//                entity.HasOne(d => d.IdApplicationNavigation)
//                    .WithMany(p => p.TutorApplicationSubject)
//                    .HasForeignKey(d => d.IdApplication)
//                    .HasConstraintName("tutor_application_subject_ibfk_1");

//                entity.HasOne(d => d.IdSubjectNavigation)
//                    .WithMany(p => p.TutorApplicationSubject)
//                    .HasForeignKey(d => d.IdSubject)
//                    .HasConstraintName("tutor_application_subject_ibfk_2");
//            });
//        }
//    }
//}
