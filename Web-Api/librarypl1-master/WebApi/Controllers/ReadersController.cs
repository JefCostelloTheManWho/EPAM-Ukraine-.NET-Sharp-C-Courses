using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly IReaderService _readerService;

        public ReadersController(IReaderService service)
        {
            _readerService = service;
        }

        // GET: api/Reader
        [HttpGet]
        public ActionResult<IEnumerable<ReaderModel>> Get()
        {
            var readers = _readerService.GetAll();
            return readers.ToList();
        }

        // GET: api/Reader/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<ReaderModel>> Get(int id)
        {
            var reader = await _readerService.GetByIdAsync(id);
            if (reader == null)
                return NotFound(id);
            return reader;
        }

        // POST: api/Reader
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ReaderModel value)
        {
            try
            {
                await _readerService.AddAsync(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction(nameof(Get), new {id = value.Id}, value);
        }

        // PUT: api/Reader
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ReaderModel value)
        {
            try
            {
                await _readerService.UpdateAsync(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        // DELETE: api/Reader/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _readerService.DeleteByIdAsync(id);
            return Ok();
        }

        //GET: api/Reader/DontReturnBooks
        [HttpGet("DontReturnBooks", Name = "GetReadersThatDontReturnBooks")]
        public ActionResult<IEnumerable<ReaderModel>> GetReadersThatDontReturnBooks()
        {
            var readers = _readerService.GetReadersThatDontReturnBooks();
            return readers.ToList();
        }
    }
}