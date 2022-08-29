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
    public class NotificationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returns a list of notifcations
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetNotificationsAsync()
        {
            IEnumerable<Notification> allNotifications = await _unitOfWork.Notifications.GetAllAsync();
            if (allNotifications != null)
            {
                return Ok(allNotifications);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a notification by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetNotificationByIdAsync(int id)
        {
            Notification? fetchedNotification = await _unitOfWork.Notifications.GetByIdAsync(id);
            if (fetchedNotification != null)
            {
                return Ok(fetchedNotification);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a notification   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> AddNotification(Notification notification)
        {
            Notification? newNotification = await _unitOfWork.Notifications.AddAsync(notification);
            if (newNotification != null)
            {
                await _unitOfWork.CompleteAsync();

                return Created("Notifciation Added Successfully", notification);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a notification by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async  Task<ActionResult> UpdateNotification(int id, JsonPatchDocument<Notification> updatesNotification)
        {
            Notification? notification = await _unitOfWork.Notifications.GetByIdAsync(id);

            if (notification != null)
            {
                updatesNotification.ApplyTo(notification);
                _unitOfWork.Notifications.Update(notification);
                await _unitOfWork.CompleteAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a notification with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<ActionResult> DeleteNotifications(int id)
        {
            Notification deletedNotification = await _unitOfWork.Notifications.GetByIdAsync(id);

            if (deletedNotification != null)
            {
                _unitOfWork.Notifications.Delete(deletedNotification);
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
