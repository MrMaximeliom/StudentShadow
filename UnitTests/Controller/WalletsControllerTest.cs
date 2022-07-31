using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class WalletsControllerTest
    {
        Initializer initializer ;
        WalletsController walletController;

        public WalletsControllerTest()
        {
            this.initializer = new Initializer();
            this.walletController =new(initializer.unitOfWork);
        }

        [Fact]
        // test GetWalletsAsync Method
        public async void GetWalletsAsync_GetAllWallets_ReturnsListOfWallets()
        {
            //Arrange

           //Act


           var listOfUsersUsingUsersController = await walletController.GetWalletsAsync();
            var okResult = listOfUsersUsingUsersController as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<Wallet>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetWalletByIdAsync Method
        public async void GetWalletByIdAsync_GetExistingWalletById_ReturnsWalletByItsId()
        {
            //Arrange
          
            int userId = 1;

            //Act

            var actionResult = await walletController.GetWalletByIdAsync(userId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetWalletByIdAsync Method
        public async void GetWalletByIdAsync_GetNonExistingWalletById_ReturnsNotFoundObject()
        {
            //Arrange
            int userId = 0;

            //Act

            var actionResult = await walletController.GetWalletByIdAsync(userId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddWallet Method
        [Fact]
        public async void AddWallet_AddingNewWallet_ReturnsNewelyAddedWallet()
        {
            //Arange

            Wallet NewWallet = new Wallet()
            {
                User = initializer.unitOfWork.Users.GetById(1),
                Amount = 1233.50M,
                QRCode = "#gttt#2d2aqw_)32w3w3"

            };

            //Act
            var CreatedResultForAddedWallet = await walletController.AddWallet(NewWallet);
            var CreatedResult = CreatedResultForAddedWallet as CreatedResult;

            //Assert
            var AddedWallet = Assert.IsAssignableFrom<Wallet>(CreatedResult.Value);

            Assert.Equal(NewWallet.ToString(), AddedWallet.ToString());
        }
        //test UpdateWallet Method
        [Fact]
        public async void UpdateWallet_UpdateExistingWalletById_ReturnsNoContentResult()
        {
            //Arange
            int WalletId = 1;

            //Act 
            JsonPatchDocument<Wallet> walletUpdate = new();
            walletUpdate.Replace(prop => prop.Amount, 2000.34M);

            var NoContentObjectResult = await walletController.UpdateWallet(WalletId, walletUpdate);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteWallet Method

        [Fact]
        public async void DeleteWallet_DeleteWalletByd_ReturnsNoContnetResult()
        {
            //Arrange
            int WalletId = 1;

            //Act
            var NoContentObjectResult = await walletController.DeleteWallets(WalletId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert

            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
