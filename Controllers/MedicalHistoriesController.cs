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
    public class MedicalHistoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicalHistoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of medical histories 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMedicalHistoriesAsync()
        {
            IEnumerable<MedicalHistory> allMedicalHistories = await _unitOfWork.MedicalHistories.GetAllAsync();
            if (allMedicalHistories != null)
            {
                return Ok(allMedicalHistories);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a medical history by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMedicalHistoriesByIdAsync(int id)
        {
            MedicalHistory? fetchedMedicalHistories = await _unitOfWork.MedicalHistories.GetByIdAsync(id);
            if (fetchedMedicalHistories != null)
            {
                return Ok(fetchedMedicalHistories);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a medical history
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMedicalHistory(MedicalHistory medicalHistory)
        {
            MedicalHistory? newMedicalHistory = await _unitOfWork.MedicalHistories.AddAsync(medicalHistory);
            if (newMedicalHistory != null)
            {
                await _unitOfWork.CompleteAsync();

                return Created("Medical History Added Successfully", medicalHistory);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a medical history by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateMedicalHistory(int id, JsonPatchDocument<MedicalHistory> medicalHistoryUpdates)
        {
            MedicalHistory? medicalHistory = await _unitOfWork.MedicalHistories.GetByIdAsync(id);

            if (medicalHistory != null)
            {
                medicalHistoryUpdates.ApplyTo(medicalHistory);
                _unitOfWork.MedicalHistories.Update(medicalHistory);
                await _unitOfWork.CompleteAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a medical history with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteMedicalHistories(int id)
        {
            MedicalHistory deletedMedicalHistory = await _unitOfWork.MedicalHistories.GetByIdAsync(id);

            if (deletedMedicalHistory != null)
            {
                _unitOfWork.MedicalHistories.Delete(deletedMedicalHistory);
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
