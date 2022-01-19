using System;
using System.Collections.Generic;
using System.Linq;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("popularBooks")]
        public ActionResult<IEnumerable<BookModel>> GetMostPopularBooks([FromQuery]int bookCount)
        {
            var books = _statisticService.GetMostPopularBooks(bookCount);

            if (books == null)
                return NotFound();

            return Ok(books);
        }

        [HttpGet("biggestReaders")]
        public ActionResult<IEnumerable<ReaderActivityModel>> GetReadersWhoTookTheMostBooks([FromQuery] int readersCount, DateTime firstDate,
            DateTime lastDate)
        {
            var readersActivity = _statisticService.GetReadersWhoTookTheMostBooks(readersCount, firstDate, lastDate);

            if (!readersActivity.Any())
                return NotFound();

            return Ok(readersActivity);
        }
    }
}