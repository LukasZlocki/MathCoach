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

        private int MinValue = 0;
        private int MaxValue = 10;

        //constr rtyrty
        public Draw()
        {
            // random ewrwerewr
            Random random = new Random();
            FirstNumber = random.Next(MinValue, MaxValue);
            SecondNumber = random.Next(MinValue, MaxValue);
        }

        public void SetUpDrawRange(int minValue, int maxValue)
        {
            minValue = MinValue;
            maxValue = MaxValue;
        }

    }
}
