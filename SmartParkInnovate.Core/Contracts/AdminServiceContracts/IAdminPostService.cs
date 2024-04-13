using SmartParkInnovate.Core.Models.AdminModels.AdminPostModels;

namespace SmartParkInnovate.Core.Contracts.AdminServiceContracts
{
    public interface IAdminPostService
    {
        public Task<IEnumerable<AdminPostViewModel>> Posts();
    }
}
