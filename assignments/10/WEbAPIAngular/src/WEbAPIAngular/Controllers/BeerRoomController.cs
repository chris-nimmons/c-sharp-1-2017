using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEbAPIAngular.Context;

namespace WEbAPIAngular.Controllers
{
    public class BeerRoomController : Controller
    {
        private readonly ColbysContext _context;
        private readonly ColbysManager _userManager;

        public BeerRoomController(ColbysContext context, ColbysManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("~/api/browse")]
        public async Task<IActionResult> Browse(int id)
        {
            var beers = await _context.Beers.ToListAsync();

            return Ok(beers);
        }

        [HttpGet]
        [Route("~/api/beers")]
        public async Task<IActionResult> GetAllBeers()
        {
            var beers = await _context.Beers.ToListAsync();

            foreach (var beer in beers)
            {
                var usersInRoom = _context.Beers
                    .ToList();
            }
            return Ok(beers);
        }
    }
}
