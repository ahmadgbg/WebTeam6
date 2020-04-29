using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTeam6.Models;

namespace WebTeam6.API.Controllers
{
    public interface IGroupRepository
    {
        Task<List<Group>> Get();
        Task<Group> Get(int id);
        Task<Group> Add(Group group, string ownerName);
        Task<Group> Update(Group group);
        Task<Group> Delete(int id);
    }

    public class GroupRepository : IGroupRepository
    {
        private readonly MainContext _context;
        public GroupRepository(MainContext context)
        {
            _context = context;
        }


        public async Task<Group> Add(Group group, string name)
        {
            var ownerName = await _context.Users.FirstAsync(n => n.UserName == name);
            var owner = await _context.Users.FindAsync(ownerName.Id);
            Console.WriteLine(owner);
            if (owner != null)
            {
                Console.WriteLine("was not null");
                group.Owner = owner;
                var result = await _context.Groups.AddAsync(group);
                owner.Groups.Add(group);
                await _context.SaveChangesAsync();
                return new Group { Id = result.Entity.Id, Name = result.Entity.Name, Owner = result.Entity.Owner };
            }
            Console.WriteLine("was null");
            return null;
        }

        public async Task<Group> Delete(int id)
        {
            var group = await _context.Groups.FindAsync(id);

            group.Members.ToList().ForEach(g => g.Groups.Remove(group));
            _context.Remove(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task<List<Group>> Get()
        {
            //return await _context.Groups.ToListAsync();
            return await _context.Groups.Include(g => g.Owner).Select(g => new Group { Owner = new User { Id = g.Owner.Id }, Name = g.Name, Members = g.Members.Select(m => new User { Id = m.Id }).ToList() }).ToListAsync();
        }

        public Task<Group> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> Update(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
