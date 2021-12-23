using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PlaneChar
    {
        public PlaneType Type { get; set; }
        
        [Range(1,2)]
        public int PlaceNumber { get; set; }

        public bool HasAmmunition { get; set; }

        [Range(0, 10)]
        public int RocketNumber { get; set; }

        public bool HasRadar { get; set; }
    }
}
