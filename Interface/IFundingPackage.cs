using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;

namespace CrowdFoundAppTeam3.Interface
{
    public interface IFundingPackage
    {
        public  Task<FundingPackage?> GetFundingPackagesByProjectAsync(int projectId);

        public Task<FundingPackageDto> CreateFundingPackageAsync(FundingPackageDto fundingPackage);
    }
}
