using StudentShadow.Controllers;
using StudentShadow.Data;
using StudentShadow.UnitOfWork;

namespace StudentShadow.UnitTests
{
    public class Initializer
    {

        public  ApplicationDBContext context;

        public  IUnitOfWork unitOfWork;

        public void InitializeObjects()
        {

            context = new();

            unitOfWork = new StudentShadow.UnitOfWork.UnitOfWork(context);

        }
        public Initializer()
        {
            InitializeObjects();
        }
    }
}
