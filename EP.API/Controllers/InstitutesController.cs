using EP.API.DTO;
using EP.Domain.Interfaces;
using EP.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InstitutesController : ControllerBase
    {
        private readonly IInstitutesService _instituteService;

        public InstitutesController(IInstitutesService instituteService)
        {
            _instituteService = instituteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InstituteResponse>>> GetAllInstitutes()
        {
            var institutes = await _instituteService.GetAllInstitutes();

            var response = institutes.Select(i => new InstituteResponse() {Uuid=i.Uuid, Name = i.Title });

            return Ok(response);
        }
    }
}
