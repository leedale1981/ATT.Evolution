using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Evolution.Entities
{
    public class Evolution
    {
        public List<Being> Beings { get; set; }
        public int NumberOfSteps { get; set; }
        public int NumberOfBeings { get; set; }
        public int NumberOfGenes { get; set; }

        public Evolution(int numberOfSteps, int numberOfBeings, int numberOfGenes)
        {
            this.NumberOfSteps = numberOfSteps;
            this.NumberOfBeings = numberOfBeings;
            this.NumberOfGenes = NumberOfGenes;
            this.CreateBeings();
        }
        public void Start()
        {
            foreach (Being being in this.Beings)
            {
                Development development = new Development(being, this.NumberOfSteps);
                development.Develop();
            }
        }

        private void CreateBeings()
        {
            this.Beings = new List<Being>();
            Being ancestralBeing = new Being(this.CreateGenes());
            this.Beings.Add(ancestralBeing);
            Being childBeing = ancestralBeing.CreateRandomMutatedChild(10);
            this.Beings.Add(childBeing);

            for (int index = 1; index < this.NumberOfBeings; index++)
            {
                childBeing = childBeing.CreateRandomMutatedChild(10);
                this.Beings.Add(childBeing);
            }
        }

        private List<Gene> CreateGenes()
        {
            List<Gene> genes = new List<Gene>();
            genes.Add(new Gene(5, GeneType.Angle));
            genes.Add(new Gene(8, GeneType.Length));
            genes.Add(new Gene(2, GeneType.Thickness));
            genes.Add(new Gene(1, GeneType.Length));
            genes.Add(new Gene(2, GeneType.Angle));
            genes.Add(new Gene(9, GeneType.Angle));
            genes.Add(new Gene(9, GeneType.Length));
            genes.Add(new Gene(8, GeneType.Thickness));
            genes.Add(new Gene(1, GeneType.Length));

            return genes;
        }
    }
}
