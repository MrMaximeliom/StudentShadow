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
    public class StudentsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of students
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetStudentsAsync()
        {
            IEnumerable<Student> allStudents = await _unitOfWork.Students.GetAllAsync();
            if (allStudents != null)
            {
                return Ok(allStudents);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a student by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            Student? fetchedStudent = await _unitOfWork.Students.GetByIdAsync(id);
            if (fetchedStudent != null)
            {
                return Ok(fetchedStudent);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a student    
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> AddStudent(Student student)
        {
            Student? newStudent = await _unitOfWork.Students.AddAsync(student);
            if (newStudent != null)
            {
                await _unitOfWork.CompleteAsync();

                return Created("Student Added Successfully", student);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a student by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult> UpdateStudent(int id, JsonPatchDocument<Student> studentUpdates)
        {
            Student? student = await _unitOfWork.Students.GetByIdAsync(id);

            if (student != null)
            {
                studentUpdates.ApplyTo(student);
                _unitOfWork.Students.Update(student);
                await _unitOfWork.CompleteAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a student with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<ActionResult> DeleteStudents(int id)
        {
            Student deletedStudent = await _unitOfWork.Students.GetByIdAsync(id);

            if (deletedStudent != null)
            {
                _unitOfWork.Students.Delete(deletedStudent);
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
