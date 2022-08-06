using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Models;
using StudentShadow.UnitOfWork;
using System.Net.Mime;

namespace StudentShadow.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class ContactUsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ContactUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of contacts
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetContactsAsync()
        {
            IEnumerable<ContactUs> allContacts = await _unitOfWork.ContactUs.GetAllAsync();
            if (allContacts != null)
            {
                return Ok(allContacts);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a contact by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetContactByIdAsync(int id)
        {
            ContactUs? fetchedContact = await _unitOfWork.ContactUs.GetByIdAsync(id);
            if (fetchedContact != null)
            {
                return Ok(fetchedContact);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a contact    
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> AddContact(ContactUs contact)
        {
            ContactUs? newContact = await _unitOfWork.ContactUs.AddAsync(contact);
            if (newContact != null)
            {
                _unitOfWork.Complete();
                return Created("Contact Added Successfully", contact);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a contact by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async  Task<ActionResult> UpdateContact(int id, JsonPatchDocument<ContactUs> contactUpdates)
        {
            ContactUs? contact = await _unitOfWork.ContactUs.GetByIdAsync(id);

            if (contact != null)
            {
                contactUpdates.ApplyTo(contact);
                _unitOfWork.ContactUs.Update(contact);
                _unitOfWork.Complete();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a contact with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<ActionResult> DeleteContact(int id)
        {
            ContactUs deletedContact= await _unitOfWork.ContactUs.GetByIdAsync(id);

            if (deletedContact != null)
            {
                _unitOfWork.ContactUs.Delete(deletedContact);
                _unitOfWork.Complete();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
