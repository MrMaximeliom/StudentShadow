using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Data;
using StudentShadow.Enums;
using StudentShadow.Models;
using StudentShadow.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StudentShadow.UnitTests.Controller
{
    public class UserControllerTest
    {

        ApplicationDBContext context ;
        UsersController userController;

        IUnitOfWork unitOfWork ;

        public void InitializeObjects()
        {
          
            context = new();

            unitOfWork = new StudentShadow.UnitOfWork.UnitOfWork(context);

            userController = new(unitOfWork);
        }
        [Fact]
        // test GetUsersAsync Method
        public async void GetUsersAsync_GetAllUsers_ReturnsListOfUsers()
        {
            //Arrange
            InitializeObjects();

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
            InitializeObjects();

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
            InitializeObjects();
           
            int userId = 4;

            //Act

            var actionResult = await unitOfWork.Users.GetByIdAsync(userId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddUser Method
        [Fact]
        public async void AddUser_AddingNewUser_ReturnsNewelyAddedUser()
        {
            //Arange
            InitializeObjects();

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
            InitializeObjects();
            int UserId = 2;

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
            InitializeObjects();
            int UserId = 3;

            //Act
            var NoContentObjectResult = await userController.DeleteUsers(UserId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert

            Assert.IsType<NoContentResult>(NoContentResult);
        }


    }
}
