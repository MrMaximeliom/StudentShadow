﻿using Microsoft.AspNetCore.Authorization;
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
    public class TokensController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TokensController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of tokens 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetTokensAsync()
        {
            IEnumerable<Token> allTokens = await _unitOfWork.Tokens.GetAllAsync();
            if (allTokens != null)
            {
                return Ok(allTokens);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Returns a token by its id
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetTokenByIdAsync(int id)
        {
            Token? fetchedToken = await _unitOfWork.Tokens.GetByIdAsync(id);
            if (fetchedToken != null)
            {
                return Ok(fetchedToken);
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Creates a token  
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddToken(Token token)
        {
            Token? newToken = await _unitOfWork.Tokens.AddAsync(token);
            if (newToken != null)
            {
                await _unitOfWork.CompleteAsync();

                return Created("Token Added Successfully", token);

            }
            else
            {
                return BadRequest();


            }

        }
        /// <summary>
        /// Updates a token by id   
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult> UpdateToken(int id, JsonPatchDocument<Token> tokenUpdates)
        {
            Token? token = await _unitOfWork.Tokens.GetByIdAsync(id);

            if (token != null)
            {
                tokenUpdates.ApplyTo(token);
                _unitOfWork.Tokens.Update(token);
                await _unitOfWork.CompleteAsync();

                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a token with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async  Task<ActionResult> DeleteTokens(int id)
        {
            Token deletedToken = await _unitOfWork.Tokens.GetByIdAsync(id);

            if (deletedToken != null)
            {
                _unitOfWork.Tokens.Delete(deletedToken);
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
