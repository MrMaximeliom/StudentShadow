using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Helpers;
using StudentShadow.Models;
using StudentShadow.UnitOfWork;
using System.Net.Mime;

namespace StudentShadow.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    //[Authorize(Roles ="Admin")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;


        public UsersController(IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }
        /// <summary>
        /// Returns a list of users 
        /// </summary>
        /// <returns></returns>

        [Authorize]
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
        [Authorize]
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
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddUser(CustomUser user)
        {
             User newUser = new User()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                Gender = user.Gender,
                SecondaryPhone = user.SecondaryPhone,
                Image = user.Image,
                QRCode = user.QRCode,
                PhoneNumber = user.PhoneNumber
            };
            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, user.Password);
            newUser.SecurityStamp = Guid.NewGuid().ToString();

            User? addedUser = await _unitOfWork.Users.AddAsync(newUser);
            if (addedUser != null)
            {
                await _unitOfWork.CompleteAsync();
                return Created("User Added Successfully", addedUser);

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
        [Authorize]
        public async Task<ActionResult> UpdateUser(int id,JsonPatchDocument<User> userUpdates)
        {
            User? user = await _unitOfWork.Users.GetByIdAsync(id);
            
            if(user != null)
            {
                userUpdates.ApplyTo(user);
                _unitOfWork.Users.Update(user);
                await _unitOfWork.CompleteAsync();
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
        [Authorize]
        public async Task<ActionResult> DeleteUsers(int id)
        {
            User deletedUser = await _unitOfWork.Users.GetByIdAsync(id);

            if(deletedUser != null)
            {
                _unitOfWork.Users.Delete(deletedUser);
                await _unitOfWork.CompleteAsync();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
