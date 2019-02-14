using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AirportWork.Models;
using AirportWork.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AirportWork.Controllers.api
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        ApplicationDbContext db;
        public SearchController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Get(string fromCode, string toCode)
        {
            var model = db.Routes.Include(p => p.AirRoutes).Include("AirRoutes.Airport")
                                .Where(p => p.AirRoutes.Any(x => x.Airport.Code == fromCode))
                                .Where(p => p.AirRoutes.Any(x => x.Airport.Code == toCode))
                                .ToList();
            List<List<string>> result = new List<List<string>>();
            foreach(var item in model)
            {
                result.Add(item.AirRoutes.OrderBy(p => p.Order).Select(p => p.Airport.Code).ToList());
            }
            return Json(result);
        }


    }
}
