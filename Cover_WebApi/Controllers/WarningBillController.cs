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
    public class WarningBillController: Controller
    {
        private readonly WarningBill_Dbcontext _context;

        public WarningBillController(WarningBill_Dbcontext context)
        {
            _context = context;
        }


        [HttpGet("all")]
        public IActionResult allWarningBill()
        {
            return Ok(_context.WarningBill.OrderByDescending(m => m.warning_date));
        }
    }
}
