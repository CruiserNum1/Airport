using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AirportWork.Models;
using AirportWork.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirportWork.Controllers.api
{
    [Route("api/[controller]")]
    public class AirportController : Controller
    {
        ApplicationDbContext db;
        public AirportController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(db.Airports.ToArray());
        }

        [HttpPost]
        public IActionResult Post([FromBody]Airport model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                db.Airports.Add(model);
                db.SaveChanges();
                return Ok(model);
            }
            catch{
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Airport model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                db.Airports.Update(model);
                db.SaveChanges();
                return Ok(model);
            }
            catch{
                return BadRequest();
            }
        }
    }
}
