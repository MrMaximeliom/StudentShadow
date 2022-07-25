using StudentShadow.Data;
using StudentShadow.Models;
using StudentShadow.Services;

namespace StudentShadow.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IGenericRepository<User> Users {get; private set;}

        public IGenericRepository<Wallet> Wallets { get; private set; }

        public IGenericRepository<Schedule> Schedules {get; private set;}

        public IGenericRepository<School> Schools {get; private set;}

        public IGenericRepository<Subject> Subjects {get; private set;}

        public IGenericRepository<HomeWork> HomeWorks {get; private set;}

        public IGenericRepository<MedicalHistory> MedicalHistories {get; private set;}

        public IGenericRepository<Grade> Grades {get; private set;}

        public IGenericRepository<Degree> Degrees {get; private set;}

        public IGenericRepository<Disease> Diseases {get; private set;}

        public IGenericRepository<Student> Students {get; private set;}

        public IGenericRepository<Token> Tokens {get; private set;}

        public IGenericRepository<AboutUs> AboutUs {get; private set;}

        public IGenericRepository<ContactUs> ContactUs {get; private set;}

        public IGenericRepository<Attendance> Attendances {get; private set;}
        public IGenericRepository<Teacher> Teachers {get; private set;}

        public IGenericRepository<Notification> Notifications { get; private set; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;

            Users = new GenericRepository<User>(_context);

            Wallets = new GenericRepository<Wallet>(_context);

            Notifications = new GenericRepository<Notification>(_context);

            Subjects = new GenericRepository<Subject>(_context);

            HomeWorks = new GenericRepository<HomeWork>(_context);

            Students = new GenericRepository<Student>(_context);

            Teachers = new GenericRepository<Teacher>(_context);

            MedicalHistories = new GenericRepository<MedicalHistory>(_context);

            Grades = new GenericRepository<Grade>(_context);

            Degrees = new GenericRepository<Degree>(_context);

            Diseases = new GenericRepository<Disease>(_context);

            AboutUs = new GenericRepository<AboutUs>(_context);

            ContactUs = new GenericRepository<ContactUs>(_context);

            Attendances = new GenericRepository<Attendance>(_context);

            Schedules = new GenericRepository<Schedule>(_context);

            Tokens = new GenericRepository<Token>(_context);

            Schools = new GenericRepository<School>(_context);
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
