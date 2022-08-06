using StudentShadow.Models;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.UnitOfWork;
using System.Net.Mime;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace StudentShadow.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of attendances 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetAttendancesAsync()
        {
            IEnumerable<Attendance> allAttendances = await _unitOfWork.Attendances.GetAllAsync();
            if (allAttendances != null)
            {
                return Ok(allAttendances);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns an attendance by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetAttendanceByIdAsync(int id)
        {
            Attendance? fetchedAttendance = await _unitOfWork.Attendances.GetByIdAsync(id);
            if (fetchedAttendance != null)
            {
                return Ok(fetchedAttendance);
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
        [Authorize]
        public async Task<IActionResult> AddAttendance(Attendance attendance)
        {
            Attendance? newAttendance = await _unitOfWork.Attendances.AddAsync(attendance);
            if (newAttendance != null)
            {
                _unitOfWork.Complete();
                return Created("Attendance Added Successfully", attendance);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates an attendance by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult> UpdateAttendance(int id, JsonPatchDocument<Attendance> attendanceUpdates)
        {
            Attendance? attendance = await _unitOfWork.Attendances.GetByIdAsync(id);

            if (attendance != null)
            {
                attendanceUpdates.ApplyTo(attendance);
                _unitOfWork.Attendances.Update(attendance);
                _unitOfWork.Complete();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes an attendance with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<ActionResult> DeleteAttendances(int id)
        {
            Attendance deletedAttendance = await _unitOfWork.Attendances.GetByIdAsync(id);

            if (deletedAttendance != null)
            {
                _unitOfWork.Attendances.Delete(deletedAttendance);
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
