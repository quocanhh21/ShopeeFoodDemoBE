using ShopeeFood.DAL.Models;
using ShopeeFood.DAL.Repositories.Contracts;
using ShopeeFood.Services.Contracts;

namespace ShopeeFood.Services.Implementations
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;

        public PartnerService(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<List<PartnerViewModel>> GetAllByCategoryId()
        {
            return await _partnerRepository.GetAllByCategoryId();
        }

        public async Task<PageResult<PartnerViewModel>> GetAllPartnerPaging(GetPartnerRequest request)
        {
            return await _partnerRepository.GetAllPartnerPaging(request);
        }

        public async Task<List<PartnerViewModel>> GetBySubCategoryId(int subCategoryId)
        {
            return await _partnerRepository.GetBySubCategoryId(subCategoryId);
        }
    }
}
