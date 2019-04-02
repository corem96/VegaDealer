using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Data.Context;
using Vega.Domain.Models;

namespace Vega.WebApi.Controllers
{
    public class MakesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MakesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<Make>> GetMakes()
        {
            return await _context.Makes.Include(m => m.Models)
                .ToListAsync();
        }
    }
}