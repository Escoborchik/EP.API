using EP.API.DTO;
using EP.Domain.Interfaces;
using EP.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace EP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EducationProgramsController : ControllerBase
    {

        private readonly IEducationProgramsService _programService;
        private readonly IHeadsService _headService;
        private readonly IInstitutesService _instituteService;
        public EducationProgramsController(IEducationProgramsService programService, IHeadsService headService,
            IInstitutesService instituteService)
        {
            _programService = programService;
            _headService = headService;
            _instituteService = instituteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EducationProgramResponse>>> GetAllEducationPrograms()
        {
            var programs = await _programService.GetAllEducationPrograms();
            var response = programs.Select(p => new EducationProgramResponse()
            {
                Uuid = p.Uuid,
                Title = p.Title,
                Status = p.Status,
                Cypher = p.Cypher,
                Level = (int)p.Level,
                Standard = (int)p.Standard,
                Institute = new InstituteResponse() { Uuid = p.Institute.Uuid, Name = p.Institute.Title },
                Head = new HeadResponse() { Uuid = p.Head.Uuid, Name = p.Head.FullName },
                AccreditationTime = p.AccreditationTime,                

            });
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateEducationProgram([FromBody] EducationProgramRequest programRequest)
        {
            var (head, errorHead) = await _headService.GetHead(programRequest.Head);

            if (!string.IsNullOrEmpty(errorHead))
            {
                return BadRequest(errorHead);
            }
            var (institute, errorInstitute) = await _instituteService.GetInstitute(programRequest.Institute);

            if (!string.IsNullOrEmpty(errorInstitute))
            {
                return BadRequest(errorInstitute);
            }

            var program = EducationProgram.Create(
                Guid.NewGuid(),
                programRequest.Title,
                programRequest.Status,
                programRequest.Cypher,
                (LevelEducation)programRequest.Level,
                (StandardEducation)programRequest.Standard,
                institute,
                head,
                programRequest.AccreditationTime);

            if (!string.IsNullOrEmpty(program.Item2))
            {
                return BadRequest(program.Item2);
            }

            var programId = await _programService.CreateEducationProgram(program.Item1);
            return Ok(programId);
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateEducationProgram([FromQuery] Guid uuId, [FromBody] EducationProgramRequest programRequest)
        {
            var (head, errorHead) = await _headService.GetHead(programRequest.Head);

            if (!string.IsNullOrEmpty(errorHead))
            {
                return BadRequest(errorHead);
            }

            var (institute, errorInstitute) = await _instituteService.GetInstitute(programRequest.Institute);

            if (!string.IsNullOrEmpty(errorInstitute))
            {
                return BadRequest(errorInstitute);
            }

            var program = EducationProgram.Create(
                uuId,
                programRequest.Title,
                programRequest.Status,
                programRequest.Cypher,
                (LevelEducation)programRequest.Level,
                (StandardEducation)programRequest.Standard,
                institute,
                head,
                programRequest.AccreditationTime);

            if (!string.IsNullOrEmpty(program.Item2))
            {
                return BadRequest(program.Item2);
            }

            try
            {
                await _programService.UpdateEducationProgram(program.Item1);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEducationProgram([FromQuery] Guid uuId)
        {

            try
            {
                await _programService.DeleteEducationProgram(uuId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("getModules")]
        public async Task<ActionResult> GETModulesFromEducationProgram([FromQuery] Guid uuid)
        {
            try
            {
                var modules = await _programService.GetModules(uuid);
                var result = modules.Select(m => new ModuleResponse() { Title = m.Title, Uuid = m.Uuid, Type = m.Type }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("addModules")]
        public async Task<ActionResult> AddModulesToEducationProgram([FromQuery] Guid uuid, [FromBody] List<Guid> modules)
        {
            try
            {
                await _programService.AddModules(uuid, modules);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}
