using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Controllers;
using StudentShadow.Models;
using Xunit;
namespace StudentShadow.UnitTests.Controller
{
    public class ContactUsControllerTest
    {
        Initializer initializer ;
        ContactUsController contactUsController;

        public ContactUsControllerTest()
        {
            this.initializer = new Initializer();
            this.contactUsController =new(initializer.unitOfWork);
        }

        [Fact]
        // test GetContactsAsync Method
        public async void GetContactsAsync_GetAllContacts_ReturnsListOfContacts()
        {
            //Arrange

           //Act


           var listOfContacts = await contactUsController.GetContactsAsync();
            var okResult = listOfContacts as OkObjectResult;



            //Assert
            var items = Assert.IsAssignableFrom<IEnumerable<ContactUs>>(okResult.Value);
            Assert.Single(items.Count().ToString());
        }
        [Fact]

        // test GetContactByIdAsync Method
        public async void GetContactByIdAsync_GetExistingContactById_ReturnsContactByItsId()
        {
            //Arrange
          
            int contactId = 1;

            //Act

            var actionResult = await contactUsController.GetContactByIdAsync(contactId);


            //Assert
            Assert.NotNull(actionResult);
        }
        // test GetContactByIdAsync Method
        public async void GetContactByIdAsync_GetNonExistingContactById_ReturnsNotFoundObject()
        {
            //Arrange
            int contactId = 0;

            //Act

            var actionResult = await contactUsController.GetContactByIdAsync(contactId);



            //Assert
            Assert.Null(actionResult);


        }
        // test AddContact Method
        [Fact]
        public async void AddContact_AddingNewContact_ReturnsNewelyAddedContact()
        {
            //Arange

            ContactUs NewContact = new ContactUs()
            {

               DeveloperName = "Moayed",
               Email="moayed@gmail.com",
               PhoneNumber="0999627379",
               JobTitle="Software Developer",
               Image="ppsdpsd/sdsdsd/sdsdsdsd.jpg"

            };

            //Act
            var CreatedResultForAddedContact = await contactUsController.AddContact(NewContact);
            var CreatedResult = CreatedResultForAddedContact as CreatedResult;

            //Assert
            var AddedContact = Assert.IsAssignableFrom<ContactUs>(CreatedResult.Value);

            Assert.Equal(NewContact.ToString(), AddedContact.ToString());
        }
        //test UpdateContact Method
        [Fact]
        public async void UpdateContact_UpdateExistingContactById_ReturnsNoContentResult()
        {
            //Arange
            int ContactId = 1;

            //Act 
            JsonPatchDocument<ContactUs> contactUpdate = new();
            contactUpdate.Replace(prop => prop.DeveloperName, "Moayed Eisa");

            var NoContentObjectResult = await contactUsController.UpdateContact(ContactId, contactUpdate);
            var NoContentResult = NoContentObjectResult as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);

        }

        //test DeleteContact Method

        [Fact]
        public async void DeleteContact_DeleteContactByd_ReturnsNoContnetResult()
        {
            //Arrange
            int SchoolId = 1;

            //Act
            var NoContentObjectResult = await contactUsController.DeleteContact(SchoolId);

            var NoContentResult = NoContentObjectResult as NoContentResult;


            //Assert
            Assert.IsType<NoContentResult>(NoContentResult);
        }





    }
}
