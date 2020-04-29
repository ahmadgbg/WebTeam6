using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTeam6.Models;

namespace WebTeam6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        // GET: api/Group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return Ok(await groupRepository.Get());
        }

        // GET: api/Group/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            return Ok(await groupRepository.Get(id));
        }

        // PUT: api/Group/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public Task<IActionResult> PutGroup(int id, Group @group)
        {
            throw new NotImplementedException();
        }

        // POST: api/Group
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group @group, string ownerName)
        {
            return await groupRepository.Add(@group, ownerName);
        }

        // DELETE: api/Group/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Group>> DeleteGroup(int id)
        {
            return await groupRepository.Delete(id);
        }
    }
}
