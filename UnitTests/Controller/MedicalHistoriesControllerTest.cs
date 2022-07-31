using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class MedicalHistoriesControllerTest
    {
        Initializer initializer;
        MedicalHistoriesController medicalHistoriesController;

        public MedicalHistoriesControllerTest()
        {
            this.initializer = new Initializer();
            this.medicalHistoriesController = new(initializer.unitOfWork);
        }

        [Fact]
        // test GetMedicalHistoriesAsync Method
        public async void GetMedicalHistoriesAsync_GetAllMedicalHistories_ReturnsListOfMedicalHistories()
        {
            //Arrange

            //Act
            var listOfMedicalHistories = await medicalHistoriesController.GetMedicalHistoriesAsync();
            var okResult = listOfMedicalHistories as OkObjectResult;

            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<MedicalHistory>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetMedicalHistoriesByIdAsync Method
        public async void GetMedicalHistoryByIdAsync_GetExistingMedicalHistoryById_ReturnsMedicalHistoriesByItsId()
        {
            //Arrange

            int medicalHistoryId = 1;

            //Act

            var actionResult = await medicalHistoriesController.GetMedicalHistoriesByIdAsync(medicalHistoryId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetMedicalHistoriesByIdAsync Method
        public async void GetMedicalHistoriesByIdAsync_GetNonExistingMedicalHistoryById_ReturnsNotFoundObject()
        {
            //Arrange
            int medicalHistoryId = 0;

            //Act

            var actionResult = await medicalHistoriesController.GetMedicalHistoriesByIdAsync(medicalHistoryId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddMedicalHistory Method
        [Fact]
        public async void AddMedicalHistory_AddingNewMedicalHistory_ReturnsNewelyAddedMedicalHistory()
        {
            //Arange

            MedicalHistory NewMedicalHistory = new MedicalHistory()
            {

                User = initializer.unitOfWork.Users.GetById(1),
               Disease = initializer.unitOfWork.Diseases.GetById(1),
               ExaminedDateTime = DateTime.Now,
               Note="Medical History"
            };

            //Act
            var CreatedResultForAddedMedicalHistory = await medicalHistoriesController.AddMedicalHistory(NewMedicalHistory);
            var CreatedResult = CreatedResultForAddedMedicalHistory as CreatedResult;

            //Assert
            var AddedMedicalHistory = Assert.IsAssignableFrom<MedicalHistory>(CreatedResult.Value);

            Assert.Equal(NewMedicalHistory.ToString(), AddedMedicalHistory.ToString());
        }
        //test UpdateMedicalHistory Method
        [Fact]
        public async void UpdateMedicalHistory_UpdateExistingMedicalHistoryById_ReturnsNoContentResult()
        {
            //Arange
            int MedicalHistoryId = 1;

            //Act 
            JsonPatchDocument<MedicalHistory> medicalHistoryUpdate = new();
            medicalHistoryUpdate.Replace(prop => prop.User.Id, 1);

            var NoContentObjectResult = await medicalHistoriesController.UpdateMedicalHistory(MedicalHistoryId, medicalHistoryUpdate);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteMedicalHistory Method

        [Fact]
        public async void DeleteMedicalHistory_DeleteMedicalHistoryByd_ReturnsNoContnetResult()
        {
            //Arrange
            int MedicalHistoryId = 1;

            //Act
            var NoContentObjectResult = await medicalHistoriesController.DeleteMedicalHistories(MedicalHistoryId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert

            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
