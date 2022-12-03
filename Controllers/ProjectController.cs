using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFoundAppTeam3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService service;

        public ProjectController(IProjectService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> Get()
        {
            List<ProjectDto> dto = await service.GetAllProjectAsync();
            if (dto is null) return NotFound("The project id is invalid or has been removed ");
            return Ok(dto);
        }
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> Post(ProjectDto dto)
        {

            ProjectDto? result = await service.CreateProjectAsync(dto);
            if (result == null) return NotFound("The specified project Id is invalid or the project has been removed. Could not create project.");
            return Ok(result);
        }
    }
}
