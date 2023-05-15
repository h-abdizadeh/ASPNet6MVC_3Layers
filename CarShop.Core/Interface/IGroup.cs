using CarShop.Database.Models;

namespace CarShop.Core.Interface;

public interface IGroup:IDisposable
{
    Task<List<Group>> GetGroups();
    Task<Group> GetGroup(int groupId);

    Task<bool> EditGroup(Group group);

    Task<bool> AddGroup(Group group);

    Task<bool> DeleteGroup(int groupId);
}
