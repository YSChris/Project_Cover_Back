using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cover_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cover_WebApi.Controllers
{   
    [Route("api/[controller]")]
    public class CoverInfoController : Controller
    {
        private readonly Cover_Dbcontext _context;

        public CoverInfoController(Cover_Dbcontext context) {
            _context = context;
        }


        [HttpGet("all")]
        public IActionResult getAll()
        { 
            return Ok(_context.CoverInfo.ToList());
        }

        [HttpGet("count_all")]
        public IActionResult getAllCount()
        {
            return Ok(_context.CoverInfo.Count());
        }

        [HttpGet("nopen_count")]
        public IActionResult getNopenCount()
        {
            return Ok(_context.CoverInfo.Where(m => (m.status == "巡检开启" || m.status == "正常开启")).Count());
        }

        [HttpGet("nclose_count")]
        public IActionResult getNcloseCount()
        {
            return Ok(_context.CoverInfo.Where(m => (m.status == "巡检关闭" || m.status == "正常关闭" || m.status == "恢复关闭")).Count());
        }

        [HttpGet("lowPower_count")]
        public IActionResult getLowPowerCount()
        {
            return Ok(_context.CoverInfo.Where(m => (m.vol_status == "低电量")).Count());
        }

        [HttpGet("warning_count")]
        public IActionResult getIllegalOpen()
        {
            return Ok(_context.CoverInfo.Where(m => m.status == "非法开启").Count());
        }

        [HttpGet("unknown")]
        public IActionResult getUnknown()
        {
            return Ok(_context.CoverInfo.Where(m => m.status == null).Count());
        }

        [HttpGet("status")]
        public IActionResult getStatus()
        {
            int[] result = { 0, 0, 0, 0, 0 };
            result[0] = _context.CoverInfo.Count();
            result[1] = _context.CoverInfo.Where(m => (m.status == "巡检开启" || m.status == "正常开启")).Count();
            result[2] = _context.CoverInfo.Where(m => (m.status == "巡检关闭" || m.status == "正常关闭" || m.status == "恢复关闭")).Count();
            result[3] = _context.CoverInfo.Where(m => m.status == "非法开启").Count();
            result[4] = _context.CoverInfo.Where(m => (m.vol_status == "低电量")).Count();
            return Ok(result);
        }

        [HttpGet("mapLable/{code}")]
        public IActionResult getMapLable(string code)
        {
            var result = _context.CoverInfo.Where(m => m.code == code).Select(m => new
            {
                code = m.code,
                name = m.name,
                lock_num = m.lock_num,
                status = m.status,
                lng = m.F_PointX,
                lat = m.F_PointY,
                vol_status = m.vol_status
            });
            return Ok(result);
         
        }

        [HttpGet("mapLable")]
        public IActionResult getMapLable()
        {
            var result = _context.CoverInfo.Select(m => new
            {
                code = m.code,
                name = m.name,
                lock_num = m.lock_num,
                status = m.status,
                lng = m.F_PointX,
                lat = m.F_PointY,
                vol_status = m.vol_status,
                IMSI = m.IMSI,
                board = m.board_num,
                device_type = m.device_type
            });
            return Ok(result);

        }

        [HttpGet("updateStatus")]
        public IActionResult updateStatus()
        {
            return Ok(_context.CoverInfo.Select(m => new
            {
                status = m.status,
                vol_status = m.vol_status
            }));
        }

        [HttpGet("illegalOpen_list")]
        public IActionResult illegalOpen()
        {
            return Ok(_context.CoverInfo.Where(m => m.status == "非法开启").Select(m => new
            {
                code = m.code,
                name = m.name,
            }));
        }

        [HttpGet("lowPower_list")]
        public IActionResult lowPowerList()
        {
            return Ok(_context.CoverInfo.Where(m => m.vol_status == "低电量").Select(m => new
            {
                code = m.code,
                name = m.name,
                bill_num = "未开单",
                bill_status = "待处理",
                warning_reason = "低电量",
                warning_date = m.newest_uploadTime

            }).OrderByDescending(m => m.warning_date));
        }

        [HttpGet("lost_contart")]
        public IActionResult lostContartList()
        {
            var result = _context.CoverInfo.Where(m => DateTime.Now.Subtract(m.newest_uploadTime.GetValueOrDefault()).TotalDays > 9.0)
                .Select(m => new
                {
                    code = m.code,
                    name = m.name,
                    bill_num = "未开单",
                    bill_status = "待处理",
                    warning_reason = "失联",
                    warning_date = m.newest_uploadTime
                });

            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
