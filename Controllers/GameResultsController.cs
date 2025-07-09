using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GameResultsApi.Services;
using GameResultsApi.Utils;
using GameResultsApi.Models;

namespace GameResultsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameResultsController : ControllerBase
    {
        private readonly GameResultService _gameResultService;
        private readonly ExcelParser _excelParser;

        public GameResultsController(GameResultService gameResultService, ExcelParser excelParser)
        {
            _gameResultService = gameResultService;
            _excelParser = excelParser;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadGameResults(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var gameResults = _excelParser.ParseExcelFile(stream);
                _gameResultService.SaveGameResults(gameResults);
            }

            return Ok("Game results uploaded successfully.");
        }

        [HttpGet]
        public ActionResult<List<GameResult>> GetGameResults()
        {
            var results = _gameResultService.GetAllGameResults();
            return Ok(results);
        }
    }
}