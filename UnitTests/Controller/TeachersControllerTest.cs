using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class TeachersControllerTest
    {
        Initializer initializer;
        TeachersController teacherController;

        public TeachersControllerTest()
        {
            this.initializer = new Initializer();
            this.teacherController = new(initializer.unitOfWork);
        }

        [Fact]
        // test GetTeachersAsync Method
        public async void GetTeachersAsync_GetAllTeachers_ReturnsListOfTeachers()
        {
            //Arrange

            //Act


            var listOfTeachers = await teacherController.GetTeachersAsync();
            var okResult = listOfTeachers as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<Teacher>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetTeacherByIdAsync Method
        public async void GetTeacherByIdAsync_GetExistingTeacherById_ReturnsTeacherByItsId()
        {
            //Arrange

            int teacherId = 1;

            //Act

            var actionResult = await teacherController.GetTeacherByIdAsync(teacherId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetTeacherByIdAsync Method
        public async void GetTeacherByIdAsync_GetNonExistingTeacherById_ReturnsNotFoundObject()
        {
            //Arrange
            int teacherId = 0;

            //Act

            var actionResult = await teacherController.GetTeacherByIdAsync(teacherId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddTeacher Method
        [Fact]
        public async void AddTeacher_AddingNewTeacher_ReturnsNewelyAddedTeacher()
        {
            //Arange

            Teacher NewTeacher = new Teacher()
            {

                School = initializer.unitOfWork.Schools.GetById(1),
                User = initializer.unitOfWork.Users.GetById(1),
                Description = "New Teacher",

            };

            //Act
            var CreatedResultForAddedTeacher = await teacherController.AddTeacher(NewTeacher);
            var CreatedResult = CreatedResultForAddedTeacher as CreatedResult;

            //Assert
            var AddedTeacher = Assert.IsAssignableFrom<Schedule>(CreatedResult.Value);

            Assert.Equal(NewTeacher.ToString(), AddedTeacher.ToString());
        }
        //test UpdateTeacher Method
        [Fact]
        public async void UpdateTeacher_UpdateExistingTeacherById_ReturnsNoContentResult()
        {
            //Arange
            int TeacherId = 1;

            //Act 
            JsonPatchDocument<Teacher> teacherUpdate = new();
            teacherUpdate.Replace(prop => prop.User.Id, "1");

            var NoContentObjectResult = await teacherController.UpdateTeacher(TeacherId, teacherUpdate);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteTeacher Method

        [Fact]
        public async void DeleteTeacher_DeleteTeacherByd_ReturnsNoContnetResult()
        {
            //Arrange
            int TeacherId = 1;

            //Act
            var NoContentObjectResult = await teacherController.DeleteTeachers(TeacherId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert

            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
