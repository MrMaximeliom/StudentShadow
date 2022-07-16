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

    public class HomeWorksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeWorksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of home works 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHomeWorksAsync()
        {
            IEnumerable<HomeWork> allHomeWorks = await _unitOfWork.HomeWorks.GetAllAsync();
            if (allHomeWorks != null)
            {
                return Ok(allHomeWorks);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a home work by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHomeWorksByIdAsync(int id)
        {
            HomeWork? fetchedHomeWorks = await _unitOfWork.HomeWorks.GetByIdAsync(id);
            if (fetchedHomeWorks != null)
            {
                return Ok(fetchedHomeWorks);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a home work
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddHomeWorks(HomeWork homeWork)
        {
            HomeWork? newHomeWork = await _unitOfWork.HomeWorks.AddAsync(homeWork);
            if (newHomeWork != null)
            {
                _unitOfWork.Complete();
                return Created("HomeWork Added Successfully", homeWork);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a home work by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateHomeWork(int id, JsonPatchDocument<HomeWork> homeWorkUpdates)
        {
            HomeWork? homeWork = await _unitOfWork.HomeWorks.GetByIdAsync(id);

            if (homeWorkUpdates != null)
            {
                homeWorkUpdates.ApplyTo(homeWork);
                _unitOfWork.HomeWorks.Update(homeWork);
                _unitOfWork.Complete();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a homeWork with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteHomeWorks(int id)
        {
            HomeWork deletedHomeWork = await _unitOfWork.HomeWorks.GetByIdAsync(id);

            if (deletedHomeWork != null)
            {
                _unitOfWork.HomeWorks.Delete(deletedHomeWork);
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
