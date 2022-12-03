using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;
using System;


public static class DtoConverters
{
    public static ProjectDto Convert(this Project project)
    {
        return new ProjectDto()
        {
            ProjectId = project.ProjectId,
            Title = project.Title,
            Description = project.Description,
            ProjectCategory = project.ProjectCategory,

            //ProjectCreator = new()
            //{
            //    FirstName = project.ProjectCreator.FirstName,
            //    LastName = project.ProjectCreator.LastName,
            //    Email = project.ProjectCreator.Email
            //}
        };
    }
}
