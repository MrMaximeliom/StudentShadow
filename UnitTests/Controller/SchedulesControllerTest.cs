using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class SchedulesControllerTest
    {
        Initializer initializer;
        SchedulesController scheduleController;

        public SchedulesControllerTest()
        {
            this.initializer = new Initializer();
            this.scheduleController = new(initializer.unitOfWork);
        }

        [Fact]
        // test GetSchedulesAsync Method
        public async void GetSchedulesAsync_GetAllSchedules_ReturnsListOfSchedules()
        {
            //Arrange

            //Act


            var listOfStudents = await scheduleController.GetSchedulesAsync();
            var okResult = listOfStudents as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<Schedule>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetScheduleByIdAsync Method
        public async void GetScheduleByIdAsync_GetExistingScheduleById_ReturnsScheduleByItsId()
        {
            //Arrange

            int scheduleId = 1;

            //Act

            var actionResult = await scheduleController.GetScheduleByIdAsync(scheduleId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetScheduleByIdAsync Method
        public async void GetScheduleByIdAsync_GetNonExistingScheduleById_ReturnsNotFoundObject()
        {
            //Arrange
            int scheduleId = 0;

            //Act

            var actionResult = await scheduleController.GetScheduleByIdAsync(scheduleId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddSchedule Method
        [Fact]
        public async void AddSchedule_AddingNewSchedule_ReturnsNewelyAddedSchedule()
        {
            //Arange

            Schedule NewSchedule = new Schedule()
            {

                SubjectId = 1,
                DateTime = DateTime.Now,
            

            };

            //Act
            var CreatedResultForAddedSubject = await scheduleController.AddSchedule(NewSchedule);
            var CreatedResult = CreatedResultForAddedSubject as CreatedResult;

            //Assert
            var AddedSchedule = Assert.IsAssignableFrom<Schedule>(CreatedResult.Value);

            Assert.Equal(NewSchedule.ToString(), AddedSchedule.ToString());
        }
        //test UpdateSchedule Method
        [Fact]
        public async void UpdateSchedule_UpdateExistingScheduleById_ReturnsNoContentResult()
        {
            //Arange
            int ScheduleId = 1;

            //Act 
            JsonPatchDocument<Schedule> scheduleUpdate = new();
            scheduleUpdate.Replace(prop => prop.SubjectId, 1);

            var NoContentObjectResult = await scheduleController.UpdateSchedule(ScheduleId, scheduleUpdate);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteSchedule Method

        [Fact]
        public async void DeleteSchedule_DeleteScheduleByd_ReturnsNoContnetResult()
        {
            //Arrange
            int ScheduleId = 1;

            //Act
            var NoContentObjectResult = await scheduleController.DeleteSchedules(ScheduleId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert

            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
