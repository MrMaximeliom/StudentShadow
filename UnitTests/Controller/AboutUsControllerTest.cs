using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class AboutUsControllerTest
    {
        Initializer initializer ;
        AboutUsController aboutUsController;

        public AboutUsControllerTest()
        {
            this.initializer = new Initializer();
            this.aboutUsController =new(initializer.unitOfWork);
        }

        [Fact]
        // test GetAboutUsAsync Method
        public async void GetAboutUsAsync_GetAllAboutUs_ReturnsListOfAboutUs()
        {
            //Arrange

           //Act


           var listOfAboutUs = await aboutUsController.GetAboutUsAsync();
            var okResult = listOfAboutUs as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<AboutUs>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetAboutUsByIdAsync Method
        public async void GetAboutUsByIdAsync_GetExistingAboutUsById_ReturnsAboutUsByItsId()
        {
            //Arrange
          
            int aboutUsId = 1;

            //Act

            var actionResult = await aboutUsController.GetAboutUsByIdAsync(aboutUsId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetAboutUsByIdAsync Method
        public async void GetAboutUsByIdAsync_GetNonExistingAboutUsById_ReturnsNotFoundObject()
        {
            //Arrange
            int aboutUsId = 0;

            //Act

            var actionResult = await aboutUsController.GetAboutUsByIdAsync(aboutUsId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddAboutUs Method
        [Fact]
        public async void AddAboutUs_AddingNewAbout_ReturnsNewelyAboutUs()
        {
            //Arange

            AboutUs NewAboutUs = new AboutUs()
            {

               CompanyName = "M&S For Systems",
               Logo="sdsdsdsd/sdsdsdsd/sdsd.png",
               WebsiteURL="www.M&S.com",
               Description="lovely company with patient developers",
               Email="all.powers@gmail.com"

            };

            //Act
            var CreatedResultForAddedAboutUs = await aboutUsController.AddAboutUs(NewAboutUs);
            var CreatedResult = CreatedResultForAddedAboutUs as CreatedResult;

            //Assert
            var AddedSchool = Assert.IsAssignableFrom<AboutUs>(CreatedResult.Value);

            Assert.Equal(NewAboutUs.ToString(), AddedSchool.ToString());
        }
        //test UpdateAboutUs Method
        [Fact]
        public async void UpdateAboutUs_UpdateExistingAboutUsById_ReturnsNoContentResult()
        {
            //Arange
            int AboutUsId = 1;

            //Act 
            JsonPatchDocument<AboutUs> aboutUsUpdates = new();
            aboutUsUpdates.Replace(prop => prop.CompanyName, "Thumbs Up");

            var NoContentObjectResult = await aboutUsController.UpdateAboutUs(AboutUsId, aboutUsUpdates);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteAboutUs Method

        [Fact]
        public async void DeleteAboutUs_DeleteAboutUsByd_ReturnsNoContnetResult()
        {
            //Arrange
            int AboutUsId = 1;

            //Act
            var NoContentObjectResult = await aboutUsController.DeleteAboutUs(AboutUsId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
