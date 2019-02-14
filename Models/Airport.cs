using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirportWork.Models
{
    public class Airport
    {
        [Key]
        public int Id {get;set;}
        [Required]
        [MaxLength(50)]
        public string Name {get;set;}
        [Required]
        public string Code {get;set;}
        public List<AirportInRoute> AirRoutes {get;set;}
    }
}