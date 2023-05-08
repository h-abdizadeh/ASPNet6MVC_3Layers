using CarShop.Database.Models;

namespace CarShop.Core.Interface;

public interface IGroup:IDisposable
{
    Task<List<Group>> GetGroups();
    Task<Group> GetGroup(int groupId);
}
