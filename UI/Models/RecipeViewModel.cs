using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class RecipeViewModel
    {
        public List<fermentable> MaltList { get; set; }
        //public fermentable Malt { get; set; }
        public double Yield { get; set; }
        public double Pounds { get; set; }
        public double Efficiency { get; set; }
        public double Gallons { get; set; }

        public double EstOG { get; set; }

        /*public double EstOG
        {
            get
            {
                return (double)(((((((Malt.yield / 100) * 46) * Pounds) * (Efficiency / 100)) / Gallons) / 1000) + 1);
            }
        }*/
    }
}