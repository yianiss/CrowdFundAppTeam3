namespace CrowdFoundAppTeam3.DTOs
{
    public class ProjectCreatorDto
    {
        public List<ProjectDto>? Projects{ get; set; }

        public int  ProjectCreatorId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

       
    }
}
