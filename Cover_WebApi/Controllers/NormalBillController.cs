using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cover_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Cover_WebApi
{
    [Route("api/[controller]")]
    public class NormalBillController: Controller
    {
        private readonly NormalBill_Dbcontext _context;

        public NormalBillController(NormalBill_Dbcontext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult getAll()
        {
            return Ok(_context.NormalBill.OrderByDescending(m => m.apply_date).ToList());
        }


    }
}