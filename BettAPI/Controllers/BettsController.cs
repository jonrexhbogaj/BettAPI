using BettAPI.Models;
using BettAPI.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BettAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class BettsController : ControllerBase
    {
        private readonly IBettRepository _bettRepository;

        public BettsController(IBettRepository bettRepository)
        {
            _bettRepository = bettRepository;
        }

        [HttpGet("")]

        public async Task<IActionResult> GetAllBetts()
        {
            var bets = await _bettRepository.GetAllBettsAsync();
            return Ok(bets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBettById([FromRoute] int id)
        {
            var bets = await _bettRepository.GetBettByIdAsync(id);
            if (bets == null)
            {
                return NotFound();
            }
            return Ok(bets);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBettAsync([FromBody] UpdatedBettModel bettModel)
        {
            var id = await _bettRepository.AddBettAsync(bettModel);
            return CreatedAtAction(nameof(GetBettById), new { id = id, controller = "betts" },bettModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBett([FromBody] BettModel bettModel, [FromRoute] int id)
        {
            await _bettRepository.UpdateBettAsync(id, bettModel);
            var bets = await _bettRepository.GetBettByIdAsync(id);
            return Ok(bets);
        }




        //[HttpPatch("{id}")]
        //public async Task<IActionResult> UpdateBettPatch([FromBody] JsonPatchDocument bettModel, [FromRoute] int id)
        //{
        //    await _bettRepository.UpdateBettPatchAsync(id, bettModel);
        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBett([FromRoute] int id)
        {
            await _bettRepository.DeleteBettAsync(id);
            return Ok();
        }
    }
}
