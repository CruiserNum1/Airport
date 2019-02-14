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
    public class RouteController : Controller
    {
        ApplicationDbContext db;
        public RouteController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(db.Routes.ToArray());
        }

        [HttpPost]
        public IActionResult Post([FromBody]Route model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                db.Routes.Add(model);
                db.SaveChanges();
                return Ok(model);
            }
            catch{
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Route model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                db.Routes.Update(model);
                db.SaveChanges();
                return Ok(model);
            }
            catch{
                return BadRequest();
            }
        }

        [HttpPost("AddAirportToRoute")]
        public IActionResult AddAirportToRoute([FromBody]AirportInRoute model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                db.AirportinRoutes.Add(model);
                db.SaveChanges();
                return Ok(model);
            }
            catch{
                return BadRequest();
            }
        }
    }
}