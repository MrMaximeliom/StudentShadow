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
    public class SchedulesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public SchedulesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of schedules 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetSchedulesAsync()
        {
            IEnumerable<Schedule> allSchedules = await _unitOfWork.Schedules.GetAllAsync();
            if (allSchedules != null)
            {
                return Ok(allSchedules);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a schedule by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetScheduleByIdAsync(int id)
        {
            Schedule? fetchedSchedule = await _unitOfWork.Schedules.GetByIdAsync(id);
            if (fetchedSchedule != null)
            {
                return Ok(fetchedSchedule);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a schedule   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> AddSchedule(Schedule schedule)
        {
            Schedule? newSchedule = await _unitOfWork.Schedules.AddAsync(schedule);
            if (newSchedule != null)
            {
                await _unitOfWork.CompleteAsync();
                return Created("Schedule Added Successfully", schedule);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a schedule by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult> UpdateSchedule(int id, JsonPatchDocument<Schedule> scheduleUpdates)
        {
            Schedule? schedule = await _unitOfWork.Schedules.GetByIdAsync(id);

            if (schedule != null)
            {
                scheduleUpdates.ApplyTo(schedule);
                _unitOfWork.Schedules.Update(schedule);
                await _unitOfWork.CompleteAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a schedule with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<ActionResult> DeleteSchedules(int id)
        {
            Schedule deletedSchedule = await _unitOfWork.Schedules.GetByIdAsync(id);

            if (deletedSchedule != null)
            {
                _unitOfWork.Schedules.Delete(deletedSchedule);
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
