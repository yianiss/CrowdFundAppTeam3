﻿using CrowdFoundAppTeam3.Domain;
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
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> Get()
        {
            List<ProjectDto> dto = await _service.GetAllProjectAsync();
            if (dto is null) return NotFound("No project has been found.");
            return Ok(dto);
        }

        [HttpGet, Route("{Category}")]
        public async Task<ActionResult<ProjectDto>> Get(ProjectCategory projectCategory)
        {
            var dto = await _service.GetProjectByCategoryAsync(projectCategory);
            if (dto == null) return NotFound("The project category is invalid or there are no projects of this category.");
            return Ok(dto);

        }

        [ApiVersion("1.1")]
        [HttpGet, Route("Search")]
        public ActionResult<List<ProjectDto>> Search(string Title, string Description)
        {
            var response = _service.SearchAsync(Title, Description);
            if (response.Result == null) return NotFound("Could not find a project that matches the specified criteria.");
            return response.Result;
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> Post(ProjectDto dto)
        {

            ProjectDto? result = await _service.CreateProjectAsync(dto);
            if (result == null) return NotFound("Could not create project.");
            return Ok(result);
        }
    }
}
