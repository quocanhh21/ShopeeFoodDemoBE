using ShopeeFood.DAL.Models;

namespace ShopeeFood.Services.Contracts
{
    public interface IPartnerService
    {
        Task<List<PartnerViewModel>> GetAllByCategoryId();

        Task<List<PartnerViewModel>> GetBySubCategoryId(int subCategoryId);

        Task<PageResult<PartnerViewModel>> GetAllPartnerPaging(GetPartnerRequest request);

        //PagedViewModel<PartnerViewModel> GetAllByCategoryId(int catagoryId, int pageIndex, int pageSized);

        //IEnumerable<Partner> GetListPartnerBySubCategoryIdPaging(int subCategory,int page, int pageSize, string sort,out int totalRow);
    }
}
