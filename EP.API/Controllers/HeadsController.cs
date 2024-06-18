using EP.API.DTO;
using EP.Application.Services;
using EP.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HeadsController : ControllerBase
    {
        private readonly IHeadsService _headsService;

        public HeadsController(IHeadsService headsService)
        {
            _headsService = headsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HeadResponse>>> GetAllHeads()
        {
            var heads = await _headsService.GetAllHeads();

            var response = heads.Select(h => new HeadResponse() {Uuid=h.Uuid, Name = h.FullName });

            return Ok(response);
             
        }
    }
}
