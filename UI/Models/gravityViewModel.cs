using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class gravityViewModel
    {
        public double ogBrix { get; set; }
        public double fgBrix { get; set; }
        public double ogGrav
        {
            get
            {
                return (ogBrix / (258.6 - ((ogBrix / 258.2) * 227.1))) + 1;
            }
        }
        public double fgGrav
        {
            get
            {
                return (1 - (0.0044993 * (ogBrix / 1.04)) + (0.0117741 * (fgBrix / 1.04)) + (0.000275806 * Math.Pow((ogBrix / 1.04), 2)) - 
                    (0.00127169 * Math.Pow((fgBrix / 1.04), 2)) - (0.00000727999 * Math.Pow((ogBrix / 1.04), 3)) + (0.0000632929 * Math.Pow((fgBrix / 1.04), 3)));
            }
        }
        public double abv
        {
            get
            {
                return ((ogGrav - fgGrav) * 131.25);
            }
        }
    }
}