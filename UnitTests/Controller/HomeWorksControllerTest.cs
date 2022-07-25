using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Enums;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class HomeWorksControllerTest
    {
        Initializer initializer;
        HomeWorksController homeWorkController;

        public HomeWorksControllerTest()
        {
            this.initializer = new Initializer();
            this.homeWorkController = new(initializer.unitOfWork);
        }

        [Fact]
        // test GetHomeWorksAsync Method
        public async void GetHomeWorksAsync_GetAllHomeWorks_ReturnsListOfHomeWorks()
        {
            //Arrange

            //Act


            var listOfHomeWorks = await homeWorkController.GetHomeWorksAsync();
            var okResult = listOfHomeWorks as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<HomeWork>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetHomeWorkByIdAsync Method
        public async void GetHomeWorkByIdAsync_GetExistingHomeWorkById_ReturnsHomeWorkByItsId()
        {
            //Arrange

            int homeWorkId = 1;

            //Act

            var actionResult = await homeWorkController.GetHomeWorksByIdAsync(homeWorkId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetHomeWorkByIdAsync Method
        public async void GetHomeWorkByIdAsync_GetNonExistingHomeWorkById_ReturnsNotFoundObject()
        {
            //Arrange
            int homeWorkId = 0;

            //Act

            var actionResult = await homeWorkController.GetHomeWorksByIdAsync(homeWorkId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddHomeWork Method
        [Fact]
        public async void AddHomeWork_AddingNewHomeWork_ReturnsNewelyAddedHomeWork()
        {
            //Arange

            HomeWork NewHomeWork = new HomeWork()
            {

              StudentId=1,
              SubjectId=1,
              TeacherId=1,
              AssignmentDateTime=DateTime.Now,
              DueDateTime=DateTime.Now,
              DueStatus=HomeWorkStatus.Pending
            

            };

            //Act
            var CreatedResultForAddedHomeWork = await homeWorkController.AddHomeWorks(NewHomeWork);
            var CreatedResult = CreatedResultForAddedHomeWork as CreatedResult;

            //Assert
            var AddedHomeWork = Assert.IsAssignableFrom<HomeWork>(CreatedResult.Value);

            Assert.Equal(NewHomeWork.ToString(), AddedHomeWork.ToString());
        }
        //test UpdateHomeWork Method
        [Fact]
        public async void UpdateHomeWork_UpdateExistingHomeWorkById_ReturnsNoContentResult()
        {
            //Arange
            int HomeWorkId = 1;

            //Act 
            JsonPatchDocument<HomeWork> homeWorkUpdate = new();
            homeWorkUpdate.Replace(prop => prop.StudentId, 1);

            var NoContentObjectResult = await homeWorkController.UpdateHomeWork(HomeWorkId, homeWorkUpdate);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteHomeWork Method

        [Fact]
        public async void DeleteHomeWork_DeleteHomeWorkByd_ReturnsNoContnetResult()
        {
            //Arrange
            int HomeWorkId = 1;

            //Act
            var NoContentObjectResult = await homeWorkController.DeleteHomeWorks(HomeWorkId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert

            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
