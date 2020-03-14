using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCoach.Models
{
    class Result
    {
        public int OK { get; set; }
        public int NOK { get; set; }
        List<Draw> DrawList = new List<Draw>();

        //constr
        public Result()
        {
            OK = 0;
            NOK = 0;
        }

        public void AddDrawResult(Draw draw)
        {
            DrawList.Add(draw);
        }


    }
}
