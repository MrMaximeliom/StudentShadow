using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class SchoolsControllerTest
    {
        Initializer initializer ;
        SchoolsController schoolController;

        public SchoolsControllerTest()
        {
            this.initializer = new Initializer();
            this.schoolController =new(initializer.unitOfWork);
        }

        [Fact]
        // test GetSchoolsAsync Method
        public async void GetSchoolsAsync_GetAllSchools_ReturnsListOfSchools()
        {
            //Arrange

           //Act


           var listOfSchools = await schoolController.GetSchoolsAsync();
            var okResult = listOfSchools as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<School>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetSchoolByIdAsync Method
        public async void GetSchoolByIdAsync_GetExistingSchoolById_ReturnsStudentByItsId()
        {
            //Arrange
          
            int schoolId = 1;

            //Act

            var actionResult = await schoolController.GetSchoolByIdAsync(schoolId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetSchoolByIdAsync Method
        public async void GetSchoolByIdAsync_GetNonExistingSchoolById_ReturnsNotFoundObject()
        {
            //Arrange
            int schoolId = 0;

            //Act

            var actionResult = await schoolController.GetSchoolByIdAsync(schoolId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddSchool Method
        [Fact]
        public async void AddSchool_AddingNewSchool_ReturnsNewelyAddedSchool()
        {
            //Arange

            School NewSchool = new School()
            {

               Name = "M&S",
               Logo="sdsdsdsd/sdsdsdsd/sdsd.png",
               WebsiteURL="www.M&S.com",

            };

            //Act
            var CreatedResultForAddedSchool = await schoolController.AddSchool(NewSchool);
            var CreatedResult = CreatedResultForAddedSchool as CreatedResult;

            //Assert
            var AddedSchool = Assert.IsAssignableFrom<School>(CreatedResult.Value);

            Assert.Equal(NewSchool.ToString(), AddedSchool.ToString());
        }
        //test UpdateSchool Method
        [Fact]
        public async void UpdateSchool_UpdateExistingSchoolById_ReturnsNoContentResult()
        {
            //Arange
            int SchoolId = 1;

            //Act 
            JsonPatchDocument<School> schoolUpdate = new();
            schoolUpdate.Replace(prop => prop.Logo, "sdsdsd/sdsd/sdds/sdsdsd.png");

            var NoContentObjectResult = await schoolController.UpdateSchool(SchoolId, schoolUpdate);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteSchool Method

        [Fact]
        public async void DeleteSchool_DeleteSchoolByd_ReturnsNoContnetResult()
        {
            //Arrange
            int SchoolId = 1;

            //Act
            var NoContentObjectResult = await schoolController.DeleteSchools(SchoolId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
