using CarShop.Core.Interface;
using CarShop.Database.Models;
using CarShop.Database.Context;

namespace CarShop.Core.Service;

public class GroupService : IGroup
{

    private DatabaseContext _context;

    public GroupService(DatabaseContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }

    public async Task<Group> GetGroup(int groupId)
    {
        //1//base on primary key field values
        var group = _context.Groups.Find(groupId);

        //2//base on any field values
        //var group = _context.Groups.FirstOrDefault(g => g.Id == groupId);

        return await Task.FromResult(group);
    }

    public async Task<List<Group>> GetGroups()
    {
        var groups = _context.Groups.ToList();

        return await Task.FromResult(groups);
    }
}
