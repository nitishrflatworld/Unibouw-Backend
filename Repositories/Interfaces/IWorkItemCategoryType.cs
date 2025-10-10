using UnibouwAPI.Models;

namespace UnibouwAPI.Repositories.Interfaces
{
    public interface IWorkItemCategoryType
    {
        Task<IEnumerable<WorkItemCategoryType>> GetAllAsync();
        Task<WorkItemCategoryType?> GetByIdAsync(Guid id);
    }
}
