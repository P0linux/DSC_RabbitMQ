using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PlaneParameters
    {
        [Range(0, int.MaxValue)]
        public int Height { get; set; }

        [Range(0, int.MaxValue)]
        public int Width { get; set; }

        [Range(0, int.MaxValue)]
        public int Length { get; set; }
    }
}
