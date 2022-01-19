using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Business.Validation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
                private readonly ICardService _cardsService;

        public CardsController(ICardService cardsService)
        {
            _cardsService = cardsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookModel>> GetAll()
        {
            var cards = _cardsService.GetAll();

            return Ok(cards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CardModel>>> GetById(int id)
        {
            var card = await _cardsService.GetByIdAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CardModel cardModel)
        {
            try
            {
                await _cardsService.AddAsync(cardModel);
            }
            catch (LibraryException e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction(nameof(Add), cardModel);
        }

        [HttpPut]
        public async Task<ActionResult> Update(CardModel cardModel)
        {
            await _cardsService.UpdateAsync(cardModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _cardsService.DeleteByIdAsync(id);

            return Ok();
        }

        [HttpGet("{id}/books")]
        public ActionResult GetBooksByCardId(int id)
        {
            var books = _cardsService.GetBooksByCardId(id);

            return Ok(books);
        }

        [HttpPost("{cardId}/books/{bookId}")]
        public async Task<ActionResult> TakeBook(int cardId, int bookId)
        {
            try
            {
                await _cardsService.TakeBookAsync(cardId, bookId);
            }
            catch (LibraryException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{cardId}/books/{bookId}")]
        public async Task<ActionResult> HandOverBook(int cardId, int bookId)
        {
            try
            {
                await _cardsService.HandOverBookAsync(cardId, bookId);
            }
            catch (LibraryException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}