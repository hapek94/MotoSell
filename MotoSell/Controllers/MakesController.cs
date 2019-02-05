using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoSell.Controllers.Resources;
using MotoSell.Core.Models;
using MotoSell.Presistance;

namespace MotoSell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        
            private readonly MotoSellDbContext context;
            private readonly IMapper mapper;

            public MakesController(MotoSellDbContext context, IMapper mapper)
            {

                this.context = context;
                this.mapper = mapper;
            }

            [HttpGet("/api/makes")]
            public async Task<IEnumerable<MakeResource>> GetMakes()
            {
                var makes = await context.Makes.Include(m => m.Models).ToListAsync();
                return mapper.Map<List<Make>, List<MakeResource>>(makes);
            }

        
    }
}