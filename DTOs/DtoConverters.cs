﻿using CrowdFoundAppTeam3.Domain;
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

            
        };
    }
    public static FundingPackageDto ConvertFundingPackage(this FundingPackage fundingPackage)
    {
        return new FundingPackageDto()
        {
            
            FundingPackageTitle = fundingPackage.FundingPackageTitle,

            FundingPackageDescription = fundingPackage.FundingPackageDescription,

            RewardPackage = fundingPackage.RewardPackage


        };
    }
    public static ProjectCreatorDto ConvertPC(this ProjectCreator projectCreator)
    {
        return new ProjectCreatorDto()
        {
            FirstName = projectCreator.FirstName,
            LastName = projectCreator.LastName,
            Email = projectCreator.Email

        };
    }
    public static BackerDto ConvertBacker(this Backer backer)
    {
        return new BackerDto()
        {
            FirstName = backer.FirstName,
            LastName = backer.LastName,
            Email = backer.Email

        };
    }
}
