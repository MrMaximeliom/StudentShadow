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
    public class WalletsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public WalletsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returns a list of wallets 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWalletsAsync()
        {
            IEnumerable<Wallet> allWallets = await _unitOfWork.Wallets.GetAllAsync();
            if (allWallets != null)
            {
                return Ok(allWallets);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a wallet by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWalletByIdAsync(int id)
        {
            Wallet? fetchedWallet = await _unitOfWork.Wallets.GetByIdAsync(id);
            if (fetchedWallet != null)
            {
                return Ok(fetchedWallet);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a wallet   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddWallet(Wallet wallet)
        {
            Wallet? newWallet = await _unitOfWork.Wallets.AddAsync(wallet);
            if (newWallet != null)
            {
                await _unitOfWork.CompleteAsync();

                return Created("Wallet Added Successfully", wallet);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a wallet by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async  Task<ActionResult> UpdateWallet(int id, JsonPatchDocument<Wallet> walletUpdates)
        {
            Wallet? wallet = await _unitOfWork.Wallets.GetByIdAsync(id);

            if (wallet != null)
            {
                walletUpdates.ApplyTo(wallet);
                _unitOfWork.Wallets.Update(wallet);
                await _unitOfWork.CompleteAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a wallet with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteWallets(int id)
        {
            Wallet deletedWallet = await _unitOfWork.Wallets.GetByIdAsync(id);

            if (deletedWallet != null)
            {
                _unitOfWork.Wallets.Delete(deletedWallet);
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
