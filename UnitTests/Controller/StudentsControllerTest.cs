using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class StudentsControllerTest
    {
        Initializer initializer ;
        StudentsController studentController;

        public StudentsControllerTest()
        {
            this.initializer = new Initializer();
            this.studentController =new(initializer.unitOfWork);
        }

        [Fact]
        // test GetStudentsAsync Method
        public async void GetStudentsAsync_GetAllStudents_ReturnsListOfStudents()
        {
            //Arrange

           //Act


           var listOfStudents = await studentController.GetStudentsAsync();
            var okResult = listOfStudents as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<Student>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetStudentByIdAsync Method
        public async void GetStudentByIdAsync_GetExistingStudentById_ReturnsStudentByItsId()
        {
            //Arrange
          
            int studentId = 1;

            //Act

            var actionResult = await studentController.GetStudentByIdAsync(studentId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetStudentByIdAsync Method
        public async void GetStudentByIdAsync_GetNonExistingStudentById_ReturnsNotFoundObject()
        {
            //Arrange
            int studentId = 0;

            //Act

            var actionResult = await studentController.GetStudentByIdAsync(studentId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddStudent Method
        [Fact]
        public async void AddStudent_AddingNewStudent_ReturnsNewelyAddedStudent()
        {
            //Arange

            Student NewStudent = new Student()
            {

               School = initializer.unitOfWork.Schools.GetById(1),
               Grade= initializer.unitOfWork.Grades.GetById(1),
               User= initializer.unitOfWork.Users.GetById(1),

            };

            //Act
            var CreatedResultForAddedSubject = await studentController.AddStudent(NewStudent);
            var CreatedResult = CreatedResultForAddedSubject as CreatedResult;

            //Assert
            var AddedStudent = Assert.IsAssignableFrom<Student>(CreatedResult.Value);

            Assert.Equal(NewStudent.ToString(), AddedStudent.ToString());
        }
        //test UpdateStudent Method
        [Fact]
        public async void UpdateStudent_UpdateExistingStudentById_ReturnsNoContentResult()
        {
            //Arange
            int StudentId = 1;

            //Act 
            JsonPatchDocument<Student> studentUpdate = new();
            studentUpdate.Replace(prop => prop.User.Id, 1);

            var NoContentObjectResult = await studentController.UpdateStudent(StudentId, studentUpdate);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteStudent Method

        [Fact]
        public async void DeleteStudent_DeleteStudentByd_ReturnsNoContnetResult()
        {
            //Arrange
            int StudentId = 1;

            //Act
            var NoContentObjectResult = await studentController.DeleteStudents(StudentId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert

            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
