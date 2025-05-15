using Events.Application.Dtos;
using Events.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Application.Services;
using WebApp.Core.enums;

namespace Events.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;
        private readonly BookingService _bookingService;
        private readonly FileService _fileService;

        public EventsController(EventService eventService, BookingService bookingService ,FileService fileService)
        {
            _eventService = eventService;
            _bookingService = bookingService;
            _fileService = fileService;
        }



        [Authorize(Roles = nameof(AppRoles.Admin))]
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromForm]AddEventDto dto , IFormFile file)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto.imagePath = await _fileService.UploadImageAsync(file ,"events");
            await _eventService.AddAsync(dto);
            return Created();

        }


        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAllAsync(int pageSize =10 , int pageNumber =1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var events = await _eventService.GetAllAsync(isTracked:false ,pageSize:pageSize ,pageNumber:pageNumber);

            if (userId != null)
            {
                List<int> bookedEventIds = await _bookingService.GetUserBookedEventIdsAsync(userId);
                foreach (var item in events)
                {
                    item.IsBooked = bookedEventIds.Contains(item.Id);
                }
                return Ok(events);
            }

            return BadRequest(ModelState);

        }



        [HttpPut("Update")]
        [Authorize(Roles = nameof(AppRoles.Admin))]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateEventDto dto ,IFormFile? file)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(file != null)
            {
                var oldEvent =await _eventService.GetByIdAsync(dto.Id);
                string newImagePath = ( await _fileService.UpdateImageAsync(file,oldEvent.imagePath))!;
                dto.imagePath = newImagePath;

                await _eventService.UpdateAsync(dto);
                return Ok(new { Success = true });

            }

            return BadRequest(new {Success =false ,Message = "Cant update Event."});

        }


        [Authorize(Roles = nameof(AppRoles.Admin))]
        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            await _eventService.RemoveAsync(id);
            return NoContent();
        }



    }
}
