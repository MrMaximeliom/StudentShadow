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
    public class AboutUsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AboutUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of information about the company
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAboutUsAsync()
        {
            IEnumerable<AboutUs> allAboutUs = await _unitOfWork.AboutUs.GetAllAsync();
            if (allAboutUs != null)
            {
                return Ok(allAboutUs);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a list of information about the company by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAboutUsByIdAsync(int id)
        {
            AboutUs? fetchedAboutUs = await _unitOfWork.AboutUs.GetByIdAsync(id);
            if (fetchedAboutUs != null)
            {
                return Ok(fetchedAboutUs);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a record with information about the company   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUser(AboutUs aboutUs)
        {
            AboutUs? newAboutUs = await _unitOfWork.AboutUs.AddAsync(aboutUs);
            if (newAboutUs != null)
            {
                _unitOfWork.Complete();
                return Created("Company Info Added Successfully", newAboutUs);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates company information by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateAboutUs(int id, JsonPatchDocument<AboutUs> aboutUsUpdates)
        {
            AboutUs? aboutUs = await _unitOfWork.AboutUs.GetByIdAsync(id);

            if (aboutUs != null)
            {
                aboutUsUpdates.ApplyTo(aboutUs);
                _unitOfWork.AboutUs.Update(aboutUs);
                _unitOfWork.Complete();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a record with company information with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteAboutUs(int id)
        {
            AboutUs deletedAboutUs = _unitOfWork.AboutUs.GetById(id);

            if (deletedAboutUs != null)
            {
                _unitOfWork.AboutUs.Delete(deletedAboutUs);
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
