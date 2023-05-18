using CarShop.Core.Interface;
using CarShop.Database.Models;
using CarShop.Database.Context;
using System.Formats.Asn1;

namespace CarShop.Core.Service;

public class GroupService : IGroup
{

    private DatabaseContext _context;

    public GroupService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> EditGroup(Group group)
    {

        try
        {
            //1
            _context.Update(group);
            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message,
                              Console.BackgroundColor = ConsoleColor.Red,
                              Console.ForegroundColor = ConsoleColor.Yellow);

            return await Task.FromResult(false);
        }
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

    public async Task<List<Group>> GetGroups(bool? notshow = null)
    {
        var groups = _context.Groups.ToList();

        if (notshow != null)
        {
            return await Task.FromResult(groups.Where(g=>g.NotShow==notshow).ToList());
        }
        return await Task.FromResult(groups);
    }

    public async Task<bool> AddGroup(Group group)
    {
        try
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message,
                              Console.BackgroundColor = ConsoleColor.Red,
                              Console.ForegroundColor = ConsoleColor.Yellow);
            return await Task.FromResult(false);
        }
    }

    public async Task<bool> DeleteGroup(int groupId)
    {
        try
        {
            var group = _context.Groups.Find(groupId);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();

                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);

        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message,
                              Console.BackgroundColor = ConsoleColor.Red,
                              Console.ForegroundColor = ConsoleColor.Yellow);
            return await Task.FromResult(false);
        }


    }
}
