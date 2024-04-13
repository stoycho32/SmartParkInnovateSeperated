using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts.AdminServiceContracts;
using SmartParkInnovate.Core.Models.AdminModels.AdminPostModels;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;

namespace SmartParkInnovate.Core.Services.AdminService
{
    public class AdminPostService : IAdminPostService
    {
        private readonly IRepository repository;

        public AdminPostService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<AdminPostViewModel>> Posts()
        {
            IEnumerable<AdminPostViewModel> posts = await this.repository.AllAsReadOnly<Post>()
                .Select(c => new AdminPostViewModel() 
                {
                    Id = c.Id,
                    WorkerUserName = c.Worker.UserName,
                    PostBody = c.PostBody,
                    PostDate = c.PostDate,
                    IsDeleted = c.IsDeleted
                })
                .ToListAsync();

            return posts;
        }
    }
}
