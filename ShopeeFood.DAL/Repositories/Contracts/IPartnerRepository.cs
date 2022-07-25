using ShopeeFood.DAL.Models;

namespace ShopeeFood.DAL.Repositories.Contracts
{
    public interface IPartnerRepository
    {
        Task<List<PartnerViewModel>> GetAllByCategoryId();

        Task<PageResult<PartnerViewModel>> GetAllPartnerPaging(GetPartnerRequest request);

        Task<List<PartnerViewModel>> GetBySubCategoryId(int subCategoryId);
    }
}
