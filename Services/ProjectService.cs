using CrowdFoundAppTeam3.Data;
using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Interface;
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

            if (projectCategory == null) return null;

            return project.Convert();

        }

        public Task<List<ProjectDto>> SearchAsync(ProjectDto title, ProjectDto description)
        {
            throw new NotImplementedException();
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
