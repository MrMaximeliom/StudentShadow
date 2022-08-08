using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class AttendancesControllerTest
    {
        Initializer initializer ;
        AttendancesController attendancesController;

        public AttendancesControllerTest()
        {
            this.initializer = new Initializer();
            this.attendancesController =new(initializer.unitOfWork);
        }

        [Fact]
        // test GetAttendancesAsync Method
        public async void GetAttendancesAsync_GetAllAttendances_ReturnsListOfAttendances()
        {
            //Arrange

           //Act


           var listOfAttendances = await attendancesController.GetAttendancesAsync();
            var okResult = listOfAttendances as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<Attendance>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetAttendanceByIdAsync Method
        public async void GetAttendanceByIdAsync_GetExistingAttendanceById_ReturnsAttendanceByItsId()
        {
            //Arrange
          
            int attendanceId = 1;

            //Act

            var actionResult = await attendancesController.GetAttendanceByIdAsync(attendanceId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetAttendanceByIdAsync Method
        public async void GetAttendanceByIdAsync_GetNonExistingAttendanceById_ReturnsNotFoundObject()
        {
            //Arrange
            int attendanceId = 0;

            //Act

            var actionResult = await attendancesController.GetAttendanceByIdAsync(attendanceId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddAttendance Method
        [Fact]
        public async void AddAttendance_AddingNewAttendance_ReturnsNewelyAddedAttendance()
        {
            //Arange

            Attendance NewAttendance = new Attendance()
            {

               User = initializer.unitOfWork.Users.GetById(1),
               Subject= initializer.unitOfWork.Subjects.GetById(1),
               DateTime=DateTime.Now,
               IsAttended=true

            };

            //Act
            var CreatedResultForAddedAttendance = await attendancesController.AddAttendance(NewAttendance);
            var CreatedResult = CreatedResultForAddedAttendance as CreatedResult;

            //Assert
            var AddedAttendance = Assert.IsAssignableFrom<Attendance>(CreatedResult.Value);

            Assert.Equal(NewAttendance.ToString(), AddedAttendance.ToString());
        }
        //test UpdateAttendance Method
        [Fact]
        public async void UpdateAttendance_UpdateExistingAttendanceById_ReturnsNoContentResult()
        {
            //Arange
            int AttendanceId = 1;

            //Act 
            JsonPatchDocument<Attendance> schoolAttendance = new();
            schoolAttendance.Replace(prop => prop.User.Id, "1");

            var NoContentObjectResult = await attendancesController.UpdateAttendance(AttendanceId, schoolAttendance);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteAttendance Method

        [Fact]
        public async void DeleteAttendance_DeleteAttendanceByd_ReturnsNoContnetResult()
        {
            //Arrange
            int attendanceId = 1;

            //Act
            var NoContentObjectResult = await attendancesController.DeleteAttendances(attendanceId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
