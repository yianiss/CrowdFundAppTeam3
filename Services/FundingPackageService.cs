using CrowdFoundAppTeam3.Data;
using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Interface;
using Microsoft.EntityFrameworkCore;

namespace CrowdFoundAppTeam3.Services
{
    public class FundingPackageService : IFundingPackage
    {

        private readonly CrowdFundDbContext _crowdFundDbContext;

        public FundingPackageService(CrowdFundDbContext dbcontext)
        {
            _crowdFundDbContext = dbcontext;
        }
        public async Task<FundingPackageDto> CreateFundingPackageAsync(FundingPackageDto fundingPackagedto)
        {

            FundingPackage fundingPackage = new FundingPackage()
            {


                FundingPackageTitle = fundingPackagedto.FundingPackageTitle,

                FundingPackageDescription = fundingPackagedto.FundingPackageDescription,

                RewardPackage = fundingPackagedto.RewardPackage



            };
            _crowdFundDbContext.FundingPackages.Add(fundingPackage);
            await _crowdFundDbContext.SaveChangesAsync();

            return fundingPackage.ConvertFundingPackage();
        }


        public async Task<FundingPackage?> GetFundingPackagesByProjectAsync(int projectId)
        {
            var project = await _crowdFundDbContext.Projects.FindAsync(projectId);
            var fundingPackage = await _crowdFundDbContext.FundingPackages

                                 .SingleOrDefaultAsync(fundingPackage => fundingPackage.Project.ProjectId == projectId);

            if (fundingPackage == null) return null;


            return  fundingPackage;

            //alternative option

            //    var project = await _crowdFundDbContext.Projects.FindAsync(projectId);
            //    var fundingPackageList = new List<FundingPackageDto>();
            //    foreach (var fundingPackage in project.FundingPackages)
            //    {
            //        fundingPackageList.Add(new FundingPackageDto
            //        {
            //            FundingPackageTitle = fundingPackage.FundingPackageTitle,
            //            FundingPackageDescription = fundingPackage.FundingPackageDescription,
            //            RewardPackage = fundingPackage.RewardPackage,
            //            ProjectId = fundingPackage.ProjectId
            //        }

            //        );


            //    }
            //   return fundingPackageList;
            //}
        }
    }
}
