using StudentShadow.Models;
using StudentShadow.Services;

namespace StudentShadow.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Wallet> Wallets { get; }
        IGenericRepository<Notification> Notifications { get; }
        IGenericRepository<Schedule> Schedules { get; }
        IGenericRepository<School> Schools { get; }
        IGenericRepository<Subject> Subjects { get; }
        IGenericRepository<HomeWork> HomeWorks { get; }
        IGenericRepository<MedicalHistory> MedicalHistories { get; }
        IGenericRepository<Grade> Grades { get; }
        IGenericRepository<Degree> Degrees { get; }
        IGenericRepository<Disease> Diseases { get; }
        IGenericRepository<Student> Students { get; }
        IGenericRepository<Token> Tokens { get; }
        IGenericRepository<AboutUs> AboutUs { get; }
        IGenericRepository<ContactUs> ContactUs { get; }
        IGenericRepository<Attendance> Attendances { get; }
    

  


    }
}
