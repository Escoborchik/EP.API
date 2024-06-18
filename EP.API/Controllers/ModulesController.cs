using EP.API.DTO;
using EP.Domain.Interfaces;
using EP.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModulesController : ControllerBase
    {
        private readonly IModulesService _moduleService;

        public ModulesController(IModulesService modulesService)
        {
            _moduleService = modulesService;
        }

        [HttpGet]
        public async Task<ActionResult<ModuleResponse>> GetModules()
        {
            var modules = await _moduleService.GetAllModules();

            var response = modules.Select(m => new ModuleResponse() { Uuid=m.Uuid, Title=m.Title,Type=m.Type});

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateModule([FromBody] ModuleRequest moduleRequest)
        {
            var module = Module.Create(Guid.NewGuid(),moduleRequest.Title,moduleRequest.Type);

            if (!string.IsNullOrEmpty(module.Item2)) 
            {
                return BadRequest(module.Item2);
            }
            var moduleId = await _moduleService.CreateModule(module.Item1);

            return Ok(moduleId);
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateModule([FromQuery]Guid uuid, [FromBody] ModuleRequest moduleRequest)
        {
            var module = Module.Create(uuid, moduleRequest.Title, moduleRequest.Type);

            if (!string.IsNullOrEmpty(module.Item2))
            {
                return BadRequest(module.Item2);
            }

            try 
            { 
                await _moduleService.UpdateModule(module.Item1);
                return Ok();
            } 
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
            
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteModule([FromQuery] Guid uuid)
        {

            try
            {
                await _moduleService.DeleteModule(uuid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }
    }
}
