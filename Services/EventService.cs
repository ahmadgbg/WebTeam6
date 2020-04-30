﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTeam6.Data;

namespace WebTeam6.Services
{
    public interface IEventService
    {
        Task<Event> Get(int id);
        Task<List<Event>> Get(Group g);
        Task<Event> Add(Event e);
        Task<Event> Update(Event e);
        Task<Event> Delete(int id);
    }

    public class EventService : IEventService
    {
        private readonly MainContext _context;

        public EventService(MainContext context)
        {
            this._context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<Event> Add(Event e)
        {
            var res = await _context.Events.AddAsync(e);

            await _context.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<Event> Delete(int id)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);

            if(ev != null)
            {
                _context.Events.Remove(ev);
                await _context.SaveChangesAsync();
            }

            return ev;
        }

        public async Task<Event> Get(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Event>> Get(Group g)
        {
            var group = await (_context.Groups.FirstOrDefaultAsync(gr => gr.Id == g.Id));
            return group.Events.ToList();
        }

        public Task<Event> Update(Event e)
        {
            throw new NotImplementedException();
        }
    }
}
