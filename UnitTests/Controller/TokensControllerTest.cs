using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Enums;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class TokensControllerTest
    {
        Initializer initializer ;
        TokensController tokenController;

        public TokensControllerTest()
        {
            this.initializer = new Initializer();
            this.tokenController =new(initializer.unitOfWork);
        }

        [Fact]
        // test GetTokensAsync Method
        public async void GetTokensAsync_GetAllTokens_ReturnsListOfTokens()
        {
            //Arrange

           //Act
           var listOfTokens = await tokenController.GetTokensAsync();
            var okResult = listOfTokens as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<Token>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetTokenByIdAsync Method
        public async void GetTokenByIdAsync_GetExistingTokenById_ReturnsTokenByItsId()
        {
            //Arrange
          
            int tokenId = 1;

            //Act

            var actionResult = await tokenController.GetTokenByIdAsync(tokenId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetTokenByIdAsync Method
        public async void GetTokenByIdAsync_GetNonExistingTokenById_ReturnsNotFoundObject()
        {
            //Arrange
            int tokenId = 0;

            //Act

            var actionResult = await tokenController.GetTokenByIdAsync(tokenId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddToken Method
        [Fact]
        public async void AddToken_AddingNewToken_ReturnsNewelyAddedToken()
        {
            //Arange

            Token NewToken = new Token()
            {
                UserId = 1,
                RegisterationToken = "dsdsdljksdlf@!#$@34234",
                OSType = OSType.Windows

            };

            //Act
            var CreatedResultForAddedToken = await tokenController.AddToken(NewToken);
            var CreatedResult = CreatedResultForAddedToken as CreatedResult;

            //Assert
            var AddedToken = Assert.IsAssignableFrom<Token>(CreatedResult.Value);

            Assert.Equal(NewToken.ToString(), AddedToken.ToString());
        }
        //test UpdateToken Method
        [Fact]
        public async void UpdateToken_UpdateExistingTokenById_ReturnsNoContentResult()
        {
            //Arange
            int TokenId = 1;

            //Act 
            JsonPatchDocument<Token> tokenUpdate = new();
            tokenUpdate.Replace(prop => prop.RegisterationToken, "sdsdf3443!!@#2323sad");

            var NoContentObjectResult = await tokenController.UpdateToken(TokenId, tokenUpdate);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteToken Method

        [Fact]
        public async void DeleteToken_DeleteTokenByd_ReturnsNoContnetResult()
        {
            //Arrange
            int TokenId = 1;

            //Act
            var NoContentObjectResult = await tokenController.DeleteTokens(TokenId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert

            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
