using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Data.Context;
using Vega.Domain.Models;
using Vega.WebApi.Controllers.Resources;

namespace Vega.WebApi.Controllers
{
    [Route("api/makes")]
    [ApiController]
    public class MakesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MakesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("extra")]
        public IActionResult GetExtra()
        {
            return Ok();
        }
        
        [HttpGet]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            if (!ModelState.IsValid)
                Console.WriteLine(ModelState.IsValid);
            var makes = await _context.Makes.Include(m => m.Models)
                .ToListAsync();

            return _mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}