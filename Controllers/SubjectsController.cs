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
    public class SubjectsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of subjects
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSubjectsAsync()
        {
            IEnumerable<Subject> allSubjects = await _unitOfWork.Subjects.GetAllAsync();
            if (allSubjects != null)
            {
                return Ok(allSubjects);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a subject by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSubjectByIdAsync(int id)
        {
            Subject? fetchedSubject = await _unitOfWork.Subjects.GetByIdAsync(id);
            if (fetchedSubject != null)
            {
                return Ok(fetchedSubject);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a subject    
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddSubject(Subject subject)
        {
            Subject? newSubject = await _unitOfWork.Subjects.AddAsync(subject);
            if (newSubject != null)
            {
                _unitOfWork.Complete();
                return Created("Subject Added Successfully", subject);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a subject by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateSubject(int id, JsonPatchDocument<Subject> subjectUpdates)
        {
            Subject? subject = await _unitOfWork.Subjects.GetByIdAsync(id);

            if (subject != null)
            {
                subjectUpdates.ApplyTo(subject);
                _unitOfWork.Subjects.Update(subject);
                _unitOfWork.Complete();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a subject with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteSubjects(int id)
        {
            Subject deletedSubject = await _unitOfWork.Subjects.GetByIdAsync(id);

            if (deletedSubject != null)
            {
                _unitOfWork.Subjects.Delete(deletedSubject);
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
