﻿namespace CrowdFoundAppTeam3.DTOs
{
    public class BackerDto
    {
        public List<ProjectDto>? Projects { get; set; }

        public int BackerId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
    }
}
