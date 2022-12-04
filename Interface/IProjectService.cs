using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;

namespace CrowdFoundAppTeam3.Interface
{
    public interface IProjectService
    {
        public Task<List<ProjectDto>> GetAllProjectAsync();

        public Task<ProjectDto> GetProjectByCategoryAsync(ProjectCategory projectCategory); 
        
        public Task<ProjectDto> CreateProjectAsync(ProjectDto project);

        public Task<List<ProjectDto>> SearchAsync
            (string Title, string Description);

        //  public Task<ProjectDto> UpdateAsync(int projectId, ProjectDto projectdto);  




    }
}
