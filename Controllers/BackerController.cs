using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFoundAppTeam3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BackerController : ControllerBase
    {
        private readonly BackerService service;

        public BackerController(BackerService service) { this.service = service; }
        [HttpGet] public async Task<ActionResult<List<BackerDto>>> Get() { List<BackerDto> dto = await service.GetAllBackerAsync(); if (dto is null) return NotFound("The project id is invalid or has been removed "); return Ok(dto); }
        [HttpPost]
        public async Task<ActionResult<BackerDto>> Post(BackerDto dto)
        {

            BackerDto? result = await service.CreateBackerAsync(dto); if (result == null) return NotFound("The specified project Id is invalid or the project has been removed. Could not create project."); return Ok(result);
        }


    }
}