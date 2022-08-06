using Microsoft.AspNetCore.Authorization;
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
    public class TeachersController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public TeachersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of teachers
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetTeachersAsync()
        {
            IEnumerable<Teacher> allTeachers = await _unitOfWork.Teachers.GetAllAsync();
            if (allTeachers != null)
            {
                return Ok(allTeachers);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a teacher by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetTeacherByIdAsync(int id)
        {
            Teacher? fetchedTeacher = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (fetchedTeacher != null)
            {
                return Ok(fetchedTeacher);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a teacher    
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddTeacher(Teacher teacher)
        {
            Teacher? newTeacher = await _unitOfWork.Teachers.AddAsync(teacher);
            if (newTeacher != null)
            {
                await _unitOfWork.CompleteAsync();

                return Created("Teacher Added Successfully", teacher);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a teacher by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult> UpdateTeacher(int id, JsonPatchDocument<Teacher> teacherUpdates)
        {
            Teacher? teacher = await _unitOfWork.Teachers.GetByIdAsync(id);

            if (teacher != null)
            {
                teacherUpdates.ApplyTo(teacher);
                _unitOfWork.Teachers.Update(teacher);
                await _unitOfWork.CompleteAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a teacher with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<ActionResult> DeleteTeachers(int id)
        {
            Teacher deletedTeacher = await _unitOfWork.Teachers.GetByIdAsync(id);

            if (deletedTeacher != null)
            {
                _unitOfWork.Teachers.Delete(deletedTeacher);
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
