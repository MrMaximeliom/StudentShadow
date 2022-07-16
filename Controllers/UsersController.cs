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
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of users 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsersAsync()
        {
            IEnumerable<User> allUsers = await _unitOfWork.Users.GetAllAsync();
            if(allUsers != null)
            {
                return Ok(allUsers);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a user by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            User? fetchedUser = await _unitOfWork.Users.GetByIdAsync(id);
            if (fetchedUser != null)
            {
                return Ok(fetchedUser);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a user    
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUser(User user)
        {
           User? newUser = await _unitOfWork.Users.AddAsync(user);
            if(newUser != null)
            {
                _unitOfWork.Complete();
                return Created("User Added Successfully", user);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a user by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateUser(int id,JsonPatchDocument<User> userUpdates)
        {
            User? user = await _unitOfWork.Users.GetByIdAsync(id);
            
            if(user != null)
            {
                userUpdates.ApplyTo(user);
                _unitOfWork.Users.Update(user);
                _unitOfWork.Complete();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a user with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteUsers(int id)
        {
            User deletedUser = await _unitOfWork.Users.GetByIdAsync(id);

            if(deletedUser != null)
            {
                _unitOfWork.Users.Delete(deletedUser);
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
