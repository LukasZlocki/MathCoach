using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCoach.Models
{
    class Draw
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        private int boundary = 10;

        //constr rtyrty
        public Draw()
        {
            // random ewrwerewr
            Random random = new Random();
            FirstNumber = random.Next(0, boundary);
            SecondNumber = random.Next(0, boundary);
        }

    }
}
