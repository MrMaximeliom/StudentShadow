using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentShadow.Helpers;
using StudentShadow.Models;
using StudentShadow.ModelsConfigurations;
namespace StudentShadow.Data
{
    public class ApplicationDBContext:IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Wallet> Wallets { get; set; } = null!;
        public DbSet<Token> Tokens { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; } = null!;
        public DbSet<MedicalHistory> MedicalHistories { get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<Disease> Diseases { get; set; } = null!;
        public DbSet<Degree> Degrees { get; set; } = null!;
        public DbSet<ContactUs> ContactUs { get; set; } = null!;
        public DbSet<AboutUs> AboutUs { get; set; } = null!;
        public DbSet<HomeWork> HomeWorks { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<School> Schools { get; set; } = null!;

        public ApplicationDBContext()
        {

        }


   
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuring Users model
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());

         
            // Configuring Wallets model
            new WalletEntityTypeConfiguration().Configure(modelBuilder.Entity<Wallet>()) ;


            // Configuring Tokens model
            new TokenEntityTypeConfiguration().Configure(modelBuilder.Entity<Token>());

            //// Configuring Teachers model
            new TeacherEntityTypeConfiguration().Configure(modelBuilder.Entity<Teacher>());

            //// Configuring Students model
            new StudentEntityTypeConfiguration().Configure(modelBuilder.Entity<Student>());

            //// Configuring Notifications model
            new NotificationEntityTypeConfiguration().Configure(modelBuilder.Entity<Notification>());

            //// Configuring Grades model
            new GradeEntityTypeConfiguration().Configure(modelBuilder.Entity<Grade>());

            //// Configuring MedicalHistories model
            new MedicalHistoryEntityTypeConfiguration().Configure(modelBuilder.Entity<MedicalHistory>());

            //// Configuring Attendences model
            new AttendanceEntityTypeConfiguration().Configure(modelBuilder.Entity<Attendance>());

            //// Configuring Diseases model
            new DiseaseEntityTypeConfiguration().Configure(modelBuilder.Entity<Disease>());

            //// Configuring Degrees model
            new DegreeEntityTypeConfiguration().Configure(modelBuilder.Entity<Degree>());

            //// Configuring ContactUs model
            new ContactUsEntityTypeConfiguration().Configure(modelBuilder.Entity<ContactUs>());

            //// Configuring AboutUS model
            new AboutUsEntityTypeConfiguration().Configure(modelBuilder.Entity<AboutUs>());

            //// Configuring HomeWorks model
            new HomeWorkEntityTypeConfiguration().Configure(modelBuilder.Entity<HomeWork>());

            //// Configuring Subjects model
            new SubjectEntityTypeConfiguration().Configure(modelBuilder.Entity<Subject>());

            //// Configuring Schedules model
            new ScheduleEntityTypeConfiguration().Configure(modelBuilder.Entity<Schedule>());

            //// Configuring Schools model
            new SchoolEntityTypeConfiguration().Configure(modelBuilder.Entity<School>());

            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "security");

            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");

            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");

            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");

            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");

            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens ", "security");

            modelBuilder.Entity<HomeWork>()
           
          
           
           ;
       
           
        }
    }
}
