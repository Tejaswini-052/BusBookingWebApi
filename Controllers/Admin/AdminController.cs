using BusBookingWebApi.Data;
using BusBookingWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BusBookingWebApi.Controllers.Admin
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly BookDbContext _context;
        public AdminController(BookDbContext context)
        {
            _context = context;
        }

        [HttpGet("Get/BusRoutes")]
        public async Task<ActionResult<IEnumerable<BusRoute>>> GetRoutes()
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

        [HttpGet("Get/BusRoutes/{id}")]
        public async Task<ActionResult<BusRoute>> GetBusRoute(int id)
        {
            try
            {
                if (_context.routes == null)
                {
                    return NotFound("No bus routes found.");
                }
                var busRoute = await _context.routes.FindAsync(id);

                if (busRoute == null)
                {
                    return NotFound("Bus route not found.");
                }

                return busRoute;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving bus route: " + ex.Message);
            }
        }

        // PUT: api/BusRoute/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/BusRoutes/{id}")]
        public async Task<IActionResult> PutBusRoute(int id, BusRoute busRoute)
        {
            if (id != busRoute.RouteId)
            {
                return BadRequest();
            }

            _context.Entry(busRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusRouteExists(id))
                {
                    return NotFound("Bus route not found");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Update Successful");
        }

        // POST: api/BusRoute
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Post/BusRoutes")]
        public async Task<ActionResult<BusRoute>> PostBusRoute(BusRoute busRoute)
        {
            try
            {
                if (_context.routes == null)
                {
                    return Problem("Entity set 'BookDbContext.routes' is null.");
                }
                _context.routes.Add(busRoute);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBusRoute", new { id = busRoute.RouteId }, busRoute);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating bus route: " + ex.Message);
            }
        }

        // DELETE: api/BusRoute/5
        [HttpDelete("Delete/BusRoutes/{id}")]
        public async Task<IActionResult> DeleteBusRoute(int id)
        {
            try
            {
                if (_context.routes == null)
                {
                    return NotFound("No bus routes found.");
                }
                var busRoute = await _context.routes.FindAsync(id);
                if (busRoute == null)
                {
                    return NotFound("Bus route not found.");
                }

                _context.routes.Remove(busRoute);
                await _context.SaveChangesAsync();

                return Ok("Route deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting bus route: " + ex.Message);
            }
        }


        private bool BusRouteExists(int id)
        {
            return (_context.routes?.Any(e => e.RouteId == id)).GetValueOrDefault();
        }

        [HttpGet("Get/Feedback")]
        public async Task<ActionResult<IEnumerable<FeedBack>>> GetFeedBack()
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

        // GET: api/FeedBack/5
        [HttpGet("Get/FeedBack/{id}")]
        public async Task<ActionResult<FeedBack>> GetFeedBack(int id)
        {
            try
            {
                if (_context.FeedBack == null)
                {
                    return NotFound("No feedback found.");
                }
                var feedback = await _context.FeedBack.FindAsync(id);

                if (feedback == null)
                {
                    return NotFound("Feedback not found.");
                }

                return feedback;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving feedback: " + ex.Message);
            }
        }

        [HttpDelete("Delete/Feedback/{id}")]
        public async Task<IActionResult> DeleteFeedBack(int id)
        {
            try
            {
                if (_context.FeedBack == null)
                {
                    return NotFound("No feedback found.");
                }
                var feedback = await _context.FeedBack.FindAsync(id);
                if (feedback == null)
                {
                    return NotFound("Feedback not found.");
                }

                _context.FeedBack.Remove(feedback);
                await _context.SaveChangesAsync();

                return Ok("Feedback deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting feedback: " + ex.Message);
            }
        }

        private bool FeedBackExists(int id)
        {
            return (_context.FeedBack?.Any(e => e.FeedbackId == id)).GetValueOrDefault();
        }


        [HttpGet("Get/RegisteredUser")]
        public async Task<ActionResult<IEnumerable<RegisterUser>>> GetregisterUser()
        {
            try
            {
                if (_context.registerUser == null)
                {
                    return NotFound("No registered users found.");
                }
                return await _context.registerUser.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving registered users: " + ex.Message);
            }
        }

        // GET: api/RegisterUsers/5
        [HttpGet("Get/RegisteredUser/{id}")]
        public async Task<ActionResult<RegisterUser>> GetRegisterUser(int id)
        {
            try
            {
                if (_context.registerUser == null)
                {
                    return NotFound("No registered users found.");
                }
                var registerUser = await _context.registerUser.FindAsync(id);

                if (registerUser == null)
                {
                    return NotFound("Registered user not found.");
                }

                return registerUser;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving registered user: " + ex.Message);
            }
        }

        // PUT: api/RegisterUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("Put/RegisteredUser/{id}")]
        //public async Task<IActionResult> PutRegisterUser(int id, RegisterUser registerUser)
        //{
        //    if (id != registerUser.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(registerUser).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RegisterUserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        // DELETE: api/RegisterUsers/5
        [HttpDelete("Delete/RegisteredUser/{id}")]
        public async Task<IActionResult> DeleteRegisterUser(int id)
        {
            try
            {
                if (_context.registerUser == null)
                {
                    return NotFound("No registered users found.");
                }
                var registerUser = await _context.registerUser.FindAsync(id);
                if (registerUser == null)
                {
                    return NotFound("Registered user not found.");
                }

                _context.registerUser.Remove(registerUser);
                await _context.SaveChangesAsync();

                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting registered user: " + ex.Message);
            }
        }



        private bool RegisterUserExists(int id)
        {
            return (_context.registerUser?.Any(e => e.UserId == id)).GetValueOrDefault();
        }



    }
}
