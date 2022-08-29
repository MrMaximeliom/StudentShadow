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
    public class DegreesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public DegreesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
   
        }
        /// <summary>
        /// Returns a list of degrees 
        /// </summary>
        /// <returns></returns>

        [Authorize]
        [HttpGet]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDegreesAsync()
        {
            IEnumerable<Degree> allDegrees = await _unitOfWork.Degrees.GetAllAsync();
            if(allDegrees != null)
            {
                return Ok(allDegrees);
            }
            else
            {

                return NotFound();
            }

        }
        /// <summary>
        /// Returns a degree by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetDegreeByIdAsync(int id)
        {
            Degree? fetchedDegree = await _unitOfWork.Degrees.GetByIdAsync(id);
            if (fetchedDegree != null)
            {
                return Ok(fetchedDegree);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a degree    
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles ="Teacher")]
        public async Task<IActionResult> AddUser(Degree degree)
        {
             Degree newDegree = new Degree()
            {
                Id = degree.Id,
                User = degree.User,
                Subject = degree.Subject,
                CharGrade = degree.CharGrade,
                DateTime = degree.DateTime,
              
            };

            Degree? addedDegree = await _unitOfWork.Degrees.AddAsync(newDegree);
            if (addedDegree != null)
            {
                await _unitOfWork.CompleteAsync();
                return Created("Degree Added Successfully", addedDegree);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a degree by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult> UpdateDegree(int id,JsonPatchDocument<Degree> degreeUpdates)
        {
            Degree? degree = await _unitOfWork.Degrees.GetByIdAsync(id);
            
            if(degree != null)
            {
                degreeUpdates.ApplyTo(degree);
                _unitOfWork.Degrees.Update(degree);
                await _unitOfWork.CompleteAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a degree with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<ActionResult> DeleteDegrees(int id)
        {
            Degree deletedDegrees = await _unitOfWork.Degrees.GetByIdAsync(id);

            if(deletedDegrees != null)
            {
                _unitOfWork.Degrees.Delete(deletedDegrees);
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
