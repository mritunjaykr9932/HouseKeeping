using HouseKeepingApi.Data;
using HouseKeepingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseKeepingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseKeepingsController : Controller
    {
        private readonly HouseDbContext houseDbContext;

        public HouseKeepingsController(HouseDbContext houseDbContext)
        {
            this.houseDbContext = houseDbContext;
        }
        //Get all data
        [HttpGet]
        public async Task<IActionResult> GetAllHouseKeepings()
        {
            var houseKeepings = await houseDbContext.Housekeepings.ToListAsync();
            return Ok(houseKeepings);
        }

        //Get Single data
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetHouseKeeping")]
        public async Task<IActionResult> GetHousekeeping([FromRoute] Guid id)
        {
            var houseKeeping = await houseDbContext.Housekeepings.FirstOrDefaultAsync(x => x.Id == id);

            if (houseKeeping != null)
            {
                return Ok(houseKeeping);
            }

            return NotFound("no data found");
        }

        //Add  data
        [HttpPost]


        public async Task<IActionResult> AddHousekeeping([FromBody] HouseKeeping houseKeeping)
        {
            houseKeeping.Id = Guid.NewGuid();
            await houseDbContext.Housekeepings.AddAsync(houseKeeping);
            await houseDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHousekeeping), new { id = houseKeeping.Id }, houseKeeping);


        }

        //update data
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateHouseKeeping([FromRoute] Guid id, [FromBody] HouseKeeping houseKeeping)
        {
            var existingHouseKeeping = await houseDbContext.Housekeepings.FirstOrDefaultAsync(x => x.Id == id);

            if (existingHouseKeeping != null)
            {
                existingHouseKeeping.Name = houseKeeping.Name;
                existingHouseKeeping.TimeOut = houseKeeping.TimeOut;
                existingHouseKeeping.TimeReq = houseKeeping.TimeReq;
                existingHouseKeeping.TimeIn = houseKeeping.TimeIn;
                existingHouseKeeping.Date = houseKeeping.Date;
                existingHouseKeeping.Feedback = houseKeeping.Feedback;
                existingHouseKeeping.Complaint = houseKeeping.Complaint;
                existingHouseKeeping.ServiceIsApproved = houseKeeping.ServiceIsApproved;
                existingHouseKeeping.ServiceRequest = houseKeeping.ServiceRequest;
                await houseDbContext.SaveChangesAsync();

                return Ok(existingHouseKeeping);
            }

            return NotFound("nhi mila");

        }
        //delete data
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteHouseKeeping([FromRoute] Guid id)
        {
            var existingHouseKeeping = await houseDbContext.Housekeepings.FirstOrDefaultAsync(x => x.Id == id);

            if (existingHouseKeeping != null)
            {
                houseDbContext.Housekeepings.Remove(existingHouseKeeping);
                await houseDbContext.SaveChangesAsync();
                return Ok(existingHouseKeeping);
            }

            return NotFound("nhi mila");

        }

    }
}
