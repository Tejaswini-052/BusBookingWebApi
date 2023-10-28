using BusBookingWebApi.Data;
using BusBookingWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusBookingWebApi.Controllers.User
{
    //[Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BookDbContext _context;

        public UserController(BookDbContext context)
        {
            _context = context;
        }



        [HttpPost("Post/Feedback")]
        public async Task<ActionResult<FeedBack>> PostContactUs(FeedBack contactUs)
        {
            try
            {
                if (_context.FeedBack == null)
                {
                    return Problem("Entity set 'BookDbContext.Contacts' is null.");
                }
                _context.FeedBack.Add(contactUs);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetContactUs", new { id = contactUs.FeedbackId }, contactUs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error posting feedback: " + ex.Message);
            }
        }

        [HttpGet("Get/FeedBack")]
        public async Task<ActionResult<IEnumerable<FeedBack>>> GetContactUs()
        {
            try
            {
                if (_context.FeedBack == null)
                {
                    return NotFound("No feedback found.");
                }
                return await _context.FeedBack.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving feedback: " + ex.Message);
            }
        }

        [HttpPost("Post/CardDetails")]
        public async Task<ActionResult<CardDetails>> PostCardDetails(CardDetails cardDetails)
        {
            try
            {
                if (_context.CardDetails == null)
                {
                    return Problem("Entity set 'BookDbContext.payments' is null.");
                }
                _context.CardDetails.Add(cardDetails);
                await _context.SaveChangesAsync();

                return Ok("Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error posting card details: " + ex.Message);
            }
        }

        // GET: api/BusRoutes
        [HttpGet("Get/BusRoutes")]
        public async Task<ActionResult<IEnumerable<BusRoute>>> Getroutes()
        {
            try
            {
                if (_context.routes == null)
                {
                    return NotFound("No bus routes found.");
                }
                return await _context.routes.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving bus routes: " + ex.Message);
            }
        }



        //GET: api/CardDetails
        //[HttpGet("Get/CardDetails")]
        // public async Task<ActionResult<IEnumerable<CardDetails>>> GetCardDetails()
        // {
        //     if (_context.CardDetails == null)
        //     {
        //         return NotFound();
        //     }
        //     return await _context.CardDetails.ToListAsync();
        // }


    }
}
