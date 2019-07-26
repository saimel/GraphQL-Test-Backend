using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLBStats.Core.Data;
using MLBStats.Core.Models;

namespace MLBStats.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    [AllowAnonymous]
    public class RESTController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IPlayerStatisticRepository _statsRepository;

        public RESTController(IPlayerRepository playerRepository, IPlayerStatisticRepository statsRepository)
        {
            _playerRepository = playerRepository;
            _statsRepository = statsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> AllPlayers()
        {
            try
            {
                var result = await _playerRepository.All();
                return Ok(result);
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
                return NoContent();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Player(int playerId)
        {
            try
            {
                var result = await _playerRepository.Get(playerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer([FromBody] Player player)
        {
            try
            {
                var result = await _playerRepository.Add(player);
                return Ok(result);
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
                return NoContent();
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddStats([FromBody] PlayerStatistic stats)
        {
            try
            {
                var result = await _statsRepository.Add(stats);
                return Ok(result);
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
                return NoContent();
            }
        }
    }
}