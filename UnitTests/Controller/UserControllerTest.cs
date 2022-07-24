using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Enums;
using StudentShadow.Models;
using Xunit;

namespace StudentShadow.UnitTests.Controller
{
    public class UserControllerTest
    {

        UsersController userController;
        Initializer initializer;

        public UserControllerTest()
        {
             initializer = new Initializer();
            userController = new(initializer.unitOfWork);
        }




        [Fact]
        // test GetUsersAsync Method
        public async void GetUsersAsync_GetAllUsers_ReturnsListOfUsers()
        {
            //Arrange

            //Act


            var listOfUsersUsingUsersController = await userController.GetUsersAsync();
            var okResult = listOfUsersUsingUsersController as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<User>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }

        [Fact]
        // test GetUserByIdAsync Method
        public async void GetUserByIdAsync_GetExistingUserById_ReturnsUserByItsId()
        {
            //Arrange

            int userId = 1;

            //Act

            var actionResult = await userController.GetUserByIdAsync(userId);


            //Assert
            Assert.NotNull(actionResult);

            
        }

        [Fact]
        // test GetUserByIdAsync Method
        public async void GetUserByIdAsync_GetNonExistingUserById_ReturnsNotFoundObject()
        {
            //Arrange
           
            int userId = 0;

            //Act

            var actionResult = await userController.GetUserByIdAsync(userId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddUser Method
        [Fact]
        public async void AddUser_AddingNewUser_ReturnsNewelyAddedUser()
        {
            //Arange

            User NewUser = new User()
            {
                FullName = "Duaa Salim",
                Email="Duaa@gmail.com",
                UserType=UserType.Parent,
                Username="@duaa",
                Password="duaa2021",
                Gender=Gender.Female,
                PrimaryPhone="0999623378",
                QRCode="#gttt#2d23W_)32w3w3"

            };

            //Act
            var CreatedResultForAddedUser = await userController.AddUser(NewUser);
            var CreatedResult = CreatedResultForAddedUser as CreatedResult;

            //Assert
            var AddedUser = Assert.IsAssignableFrom<User>(CreatedResult.Value);

            Assert.Equal(NewUser.ToString(), AddedUser.ToString());
        }

        //test UpdateUser Method
        [Fact]
        public async void UpdateUser_UpdateExistingUserById_ReturnsNoContentResult()
        {
            //Arange
            int UserId = 1;

            //Act 
            JsonPatchDocument<User> userUpdate = new();
            userUpdate.Replace(prop => prop.FullName, "Ahmed Khalid");

            var NoContentObjectResult = await userController.UpdateUser(UserId, userUpdate);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteUser Method

        [Fact]
        public async void DeleteUser_DeleteUserByd_ReturnsNoContnetResult()
        {
            //Arrange
            int UserId = 1;

            //Act
            var NoContentObjectResult = await userController.DeleteUsers(UserId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert

            Assert.IsType<NoContentResult>(NoContentResult);
        }


    }
}
