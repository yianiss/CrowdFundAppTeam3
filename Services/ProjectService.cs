using CrowdFoundAppTeam3.Data;
using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrowdFoundAppTeam3.Services
{
    public class ProjectService : IProjectService
    {
        private readonly CrowdFundDbContext _crowdFundDbContext;

        public ProjectService(CrowdFundDbContext dbcontext)
        {
            _crowdFundDbContext = dbcontext;
        }

        public async Task<ProjectDto> CreateProjectAsync(ProjectDto projectdto)
        {
            var ProjectCreator = _crowdFundDbContext
                .ProjectCreators
                .Where(pc => pc.ProjectCreatorId == projectdto
                .ProjectCreatorId)
                .ToList();
            //ProjectCreator projectcreator = await CrowdFundDbContext.Users.SingleOrDefaultAsync(pc => pc.Id == projectdto.ProjectCreator!.UserId));

            Project project = new Project()
            {
                Title = projectdto.Title,
                Description = projectdto.Description,
                ProjectCategory = projectdto.ProjectCategory,


            };
            _crowdFundDbContext.Projects.Add(project);
            await _crowdFundDbContext.SaveChangesAsync();

            return project.Convert();
        }

        public async Task<List<ProjectDto>> GetAllProjectAsync()
        {
            return await _crowdFundDbContext.Projects
           .Include(project => project.ProjectCreator)
           .Select(project => project.Convert())
           .ToListAsync();
        }

        public async Task<ProjectDto?> GetProjectByCategoryAsync(ProjectCategory projectCategory)
        {
            var project = await _crowdFundDbContext.Projects
                //.Include(project => project.ProjectCategory)
                .SingleOrDefaultAsync(project => project.ProjectCategory == projectCategory);

            return project?.Convert();

        }

        public async Task<List<ProjectDto>> SearchAsync
            ([FromQuery] string Title, [FromQuery] string Description)
        {
            var results = _crowdFundDbContext.Projects.Include(pc => pc.ProjectCreator).Select(p => p);

            if (Title != null)
            {
                results = results.Where(p => p.Title.ToLower().Contains(Title.ToLower()));
            }

            if (Description != null)
            {
                results = results.Where(p => p.Description.ToLower().Contains(Description.ToLower()));
            }

            var resultsList = await results.ToListAsync();

            if (resultsList == null) return null;

            List<ProjectDto> response = new();
            foreach (var p in resultsList)
            {
                response.Add(p.Convert());
            }

            return response;
        }



        //public async Task<ProjectDto> UpdateAsync(int projectId, ProjectDto projectdto)
        //{
        //    Project? project = await _crowdFundDbContext.Projects
        //         .Include(project => project.ProjectCreator)
        //         .SingleOrDefaultAsync(p => p.ProjectId == projectId);


        //    if (projectdto.Title is not null) project.Title = projectdto.Title;
        //    if (projectdto.Description is not null) project.Description = projectdto.Description;
        //    project.ProjectCategory = projectdto.ProjectCategory;
        //    if (projectdto.ProjectCreator is not null)
        //    {
        //        var projectCreator = _crowdFundDbContext.ProjectCreators.SingleOrDefault(pc => pc.ProjectCreatorId == projectdto.ProjectCreator.ProjectCreatorId);
        //        if (projectCreator is not null) project.ProjectCreator = projectCreator;
        //    }

        //    await _crowdFundDbContext.SaveChangesAsync();

        //    return project.Convert();
        //}
    }
}
