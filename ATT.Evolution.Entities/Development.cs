using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Evolution.Entities
{
    public class Development
    {
        public Being Being { get; set; }
        public int Steps { get; set; }
        private int currentStep = 0;

        public Development(Being being, int steps)
        {
            this.Being = being;
            this.Steps = steps;
        }

        public void Develop()
        {
            this.Being.Develop();
            this.currentStep++;

            while (currentStep < this.Steps)
            {
                this.Develop();
            }
        }
    }
}
