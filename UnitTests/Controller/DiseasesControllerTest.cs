using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class DiseasesControllerTest
    {
        Initializer initializer ;
        DiseasesController diseasesController;

        public DiseasesControllerTest()
        {
            this.initializer = new Initializer();
            this.diseasesController =new(initializer.unitOfWork);
        }

        [Fact]
        // test GetDiseasesAsync Method
        public async void GetDiseasesAsync_GetAllDiseases_ReturnsListOfDiseases()
        {
            //Arrange

           //Act


           var listOfDiseases = await diseasesController.GetDiseasesAsync();
            var okResult = listOfDiseases as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<Disease>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetDiseaseByIdAsync Method
        public async void GetDiseaseByIdAsync_GetExistingDiseaseById_ReturnsDiseaseByItsId()
        {
            //Arrange
          
            int diseaseId = 1;

            //Act

            var actionResult = await diseasesController.GetDiseaseByIdAsync(diseaseId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetDiseaseByIdAsync Method
        public async void GetDiseaseByIdAsync_GetNonExistingDiseaseById_ReturnsNotFoundObject()
        {
            //Arrange
            int schoolId = 0;

            //Act

            var actionResult = await diseasesController.GetDiseaseByIdAsync(schoolId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddDisease Method
        [Fact]
        public async void AddDisease_AddingNewDisease_ReturnsNewelyAddedDisease()
        {
            //Arange

            Disease NewDisease = new Disease()
            {

               Name = "Disabeates",
               Syptoms="low suger in body",
               GeneralGuides="stay away from suger",

            };

            //Act
            var CreatedResultForAddedDisease = await diseasesController.AddUser(NewDisease);
            var CreatedResult = CreatedResultForAddedDisease as CreatedResult;

            //Assert
            var AddedDisease = Assert.IsAssignableFrom<Disease>(CreatedResult.Value);

            Assert.Equal(NewDisease.ToString(), AddedDisease.ToString());
        }
        //test UpdateDisease Method
        [Fact]
        public async void UpdateDisease_UpdateExistingDiseaseById_ReturnsNoContentResult()
        {
            //Arange
            int DiseaseId = 1;

            //Act 
            JsonPatchDocument<Disease> diseaseUpdate = new();
            diseaseUpdate.Replace(prop => prop.Name, "Diabeates Disease");

            var NoContentObjectResult = await diseasesController.UpdateDisease(DiseaseId, diseaseUpdate);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteDisease Method

        [Fact]
        public async void DeleteDisease_DeleteDiseaseByd_ReturnsNoContnetResult()
        {
            //Arrange
            int DiseaseId = 1;

            //Act
            var NoContentObjectResult = await diseasesController.DeleteDisease(DiseaseId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
