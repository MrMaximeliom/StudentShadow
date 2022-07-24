using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class SubjectsControllerTest
    {
        Initializer initializer ;
        SubjectsController subjectController;

        public SubjectsControllerTest()
        {
            this.initializer = new Initializer();
            this.subjectController =new(initializer.unitOfWork);
        }

        [Fact]
        // test GetSubjectsAsync Method
        public async void GetSubjectsAsync_GetAllStudents_ReturnsListOfStudents()
        {
            //Arrange

           //Act


           var listOfSubjects = await subjectController.GetSubjectsAsync();
            var okResult = listOfSubjects as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<Subject>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetSubjectByIdAsync Method
        public async void GetSubjectByIdAsync_GetExistingSubjectById_ReturnsSubjectByItsId()
        {
            //Arrange
          
            int subjectId = 1;

            //Act

            var actionResult = await subjectController.GetSubjectByIdAsync(subjectId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetSubjectByIdAsync Method
        public async void GetSubjectByIdAsync_GetNonExistingSubjectById_ReturnsNotFoundObject()
        {
            //Arrange
            int subjectId = 0;

            //Act

            var actionResult = await subjectController.GetSubjectByIdAsync(subjectId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddSubject Method
        [Fact]
        public async void AddSubject_AddingNewSubject_ReturnsNewelyAddedSubject()
        {
            //Arange

            Subject NewSubject = new Subject()
            {

                Title = "English",
                GradeId = 1,
                StartDateTime = DateTime.Now,
                FullDegree = 100,
                PassDegree=60,

            };

            //Act
            var CreatedResultForAddedSubject = await subjectController.AddSubject(NewSubject);
            var CreatedResult = CreatedResultForAddedSubject as CreatedResult;

            //Assert
            var AddedSubject = Assert.IsAssignableFrom<Subject>(CreatedResult.Value);

            Assert.Equal(NewSubject.ToString(), AddedSubject.ToString());
        }
        //test UpdateSubject Method
        [Fact]
        public async void UpdateSubject_UpdateExistingSubjectById_ReturnsNoContentResult()
        {
            //Arange
            int SubjectId = 1;

            //Act 
            JsonPatchDocument<Subject> subjectUpdate = new();
            subjectUpdate.Replace(prop => prop.Title, "English World");

            var NoContentObjectResult = await subjectController.UpdateSubject(SubjectId, subjectUpdate);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteSubject Method

        [Fact]
        public async void DeleteSubject_DeleteSubjectByd_ReturnsNoContnetResult()
        {
            //Arrange
            int SubjectId = 1;

            //Act
            var NoContentObjectResult = await subjectController.DeleteSubjects(SubjectId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert

            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
