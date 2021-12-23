using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Plane
    {
        [Required]
        public string Id { get; set; } = "";

        [Required]
        public string Model { get; set; } = "";

        [Required]
        public string Origin { get; set; } = "";

        [Required]
        public PlaneChar[] Chars { get; set; } = Array.Empty<PlaneChar>();

        [Required]
        public PlaneParameters Parameters { get; set; } = new PlaneParameters();

        [Required]
        [Range(0, int.MaxValue)]
        public float Price { get; set; }
    }
}
