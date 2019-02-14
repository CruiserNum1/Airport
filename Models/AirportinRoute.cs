using System;
using System.ComponentModel.DataAnnotations;

namespace AirportWork.Models
{
    public class AirportInRoute
    {
        [Key]
        public int Id { get; set; }
        public int RouteId { get; set; }
        public Route Route {get;set;}
        public int AirportId { get; set; }
        public Airport Airport {get;set;}
        public int Order { get; set; } 
    }
}