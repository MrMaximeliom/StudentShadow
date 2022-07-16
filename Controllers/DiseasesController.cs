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
    public class DiseasesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiseasesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of diseases 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDiseasesAsync()
        {
            IEnumerable<Disease> allDiseases = await _unitOfWork.Diseases.GetAllAsync();
            if (allDiseases != null)
            {
                return Ok(allDiseases);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a disease by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDiseaseByIdAsync(int id)
        {
            Disease? fetchedDisease = await _unitOfWork.Diseases.GetByIdAsync(id);
            if (fetchedDisease != null)
            {
                return Ok(fetchedDisease);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a disease   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUser(Disease disease)
        {
            Disease? newDisease = await _unitOfWork.Diseases.AddAsync(disease);
            if (newDisease != null)
            {
                _unitOfWork.Complete();
                return Created("Disease Added Successfully", disease);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a disease by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateDisease(int id, JsonPatchDocument<Disease> diseaseUpdates)
        {
            Disease? disease = await _unitOfWork.Diseases.GetByIdAsync(id);

            if (disease != null)
            {
                diseaseUpdates.ApplyTo(disease);
                _unitOfWork.Diseases.Update(disease);
                _unitOfWork.Complete();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a disease with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteDisease(int id)
        {
            Disease deletedDisease = await _unitOfWork.Diseases.GetByIdAsync(id);

            if (deletedDisease != null)
            {
                _unitOfWork.Diseases.Delete(deletedDisease);
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
