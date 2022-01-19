using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _booksService;

        public BooksController(IBookService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookModel>> GetByFilter([FromQuery] FilterSearchModel model)
        {
            var books = _booksService.GetByFilter(model);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BookModel>>> GetById(int id)
        {
            var book = await _booksService.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] BookModel bookModel)
        {
            try
            {
                await _booksService.AddAsync(bookModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction(nameof(Add), new {bookModel.Id}, bookModel);
        }

        [HttpPut]
        public async Task<ActionResult> Update(BookModel bookModel)
        {
            try
            {
                await _booksService.UpdateAsync(bookModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _booksService.DeleteByIdAsync(id);

            return Ok();
        }
    }
}