﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioManager.Models;
using Newtonsoft.Json;

namespace PortfolioManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ProfolioManagerContext _context;

        public LoginController(ProfolioManagerContext context)
        {
            _context = context;
        }

        //// GET: api/Login
        //[HttpGet]
        //public string GetUsers()
        //{
        //    var i = _context.Users;
        //    var res = JsonConvert.SerializeObject(i);
        //    return res;
        //}

        // GET: api/Login
        [HttpGet]
        public string GetUsers()
        {
            var i = _context.Users;
            ResponseResult<DbSet<Users>> rr = new ResponseResult<DbSet<Users>>();
            rr.Data = i;
            var res = JsonConvert.SerializeObject(rr);
            return res;
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] string id, [FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Soeid)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> PostUsers([FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(users);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsersExists(users.Soeid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsers", new { id = users.Soeid }, users);
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return Ok(users);
        }

        private bool UsersExists(string id)
        {
            return _context.Users.Any(e => e.Soeid == id);
        }
    }
}