using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Data.Entities;
using BookStore.Services.Service.Interfaces;

namespace BookStore.API.API.Controllers
{
    [Route("api/PublishersAPI")]
    [ApiController]
    public class PublishersAPIController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersAPIController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: api/PublishersAPI
        [HttpGet("Publishers")]
        public IEnumerable<Publisher> GetPublishers()
        {
            var publishers = _publisherService.GetPublishers();
            return publishers;
        }

        // GET: api/PublishersAPI/5
        [HttpGet("Publisher")]
        public ActionResult<Publisher> GetPublisher(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return Ok(publisher);
        }

        // PUT: api/PublishersAPI/5
        [HttpPut("EditPublisher")]
        public IActionResult EditPublisher(int id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest();
            }

            try
            {
                _publisherService.Edit(publisher);
                return Ok(publisher);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error occured: { ex}.");
            }
        }

        // POST: api/PublishersAPI
        [HttpPost("AddPublisher")]
        public ActionResult<Publisher> AddPublisher(Publisher publisher)
        {
            _publisherService.Add(publisher);
            return CreatedAtAction("AddPublisher", new { id = publisher.Id }, publisher);
        }

        // DELETE: api/PublishersAPI/5
        [HttpDelete("DeletePublisher")]
        public ActionResult<Publisher> DeletePublisher(int id)
        {
            _publisherService.Delete(id);
            return NoContent(); // return Ok();
        }

    }
}
