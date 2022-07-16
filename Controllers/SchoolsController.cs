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
    public class SchoolsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public SchoolsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of schools
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSchoolsAsync()
        {
            IEnumerable<School> allSchools = await _unitOfWork.Schools.GetAllAsync();
            if (allSchools != null)
            {
                return Ok(allSchools);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a school by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSchoolByIdAsync(int id)
        {
            School? fetchedSchool = await _unitOfWork.Schools.GetByIdAsync(id);
            if (fetchedSchool != null)
            {
                return Ok(fetchedSchool);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a school    
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddSchool(School school)
        {
            School? newSchool = await _unitOfWork.Schools.AddAsync(school);
            if (newSchool != null)
            {
                _unitOfWork.Complete();
                return Created("School Added Successfully", school);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a school by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateSchool(int id, JsonPatchDocument<School> schoolUpdates)
        {
            School? school = await _unitOfWork.Schools.GetByIdAsync(id);

            if (school != null)
            {
                schoolUpdates.ApplyTo(school);
                _unitOfWork.Schools.Update(school);
                _unitOfWork.Complete();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a school with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteSchools(int id)
        {
            School deletedSchool = await _unitOfWork.Schools.GetByIdAsync(id);

            if (deletedSchool != null)
            {
                _unitOfWork.Schools.Delete(deletedSchool);
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

