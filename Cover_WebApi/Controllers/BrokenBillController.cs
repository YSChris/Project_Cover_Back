using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cover_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Cover_WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BrokenBillController : Controller
    {
        private readonly BrokenBill_Dbcontext _context;

        public BrokenBillController(BrokenBill_Dbcontext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult allBrokenBill()
        {
            return Ok(_context.BrokenBill.OrderByDescending(m => m.warning_date));
        }
    }
}