using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Evolution.Entities
{
    public class Being
    {
        private List<Gene> originalGenes;
        public List<Gene> Genes { get; set; }
        public List<Cell> Cells { get; set; }

        public Being(List<Gene> genes)
        {
            this.originalGenes = genes;
            this.Genes = new List<Gene>(genes);
            this.Cells = new List<Cell>();
        }

        public void Develop()
        {
            this.Cells.Add(new Cell(this.Genes));
        }

        public Being CreateChild()
        {
            return new Being(this.originalGenes);
        }

        public Being CreateRandomMutatedChild(int mutationStrength)
        {
            List<Gene> mutatedGenes = new List<Gene>(this.originalGenes);
            int[] genesToMutate = { 3, 0, 8, 5 };
            int upOrDown = new Random().Next(0, 2);

            for (int index = 0; index < genesToMutate.Length; index++)
            {
                if (upOrDown == 0)
                {
                    int geneValue = mutatedGenes[genesToMutate[index]].Value;
                    if (geneValue + mutationStrength >= 20)
                    {
                        mutatedGenes[genesToMutate[index]] =
                            new Gene(geneValue -= mutationStrength, mutatedGenes[genesToMutate[index]].GeneType);
                    }
                    else
                    {
                        mutatedGenes[genesToMutate[index]] =
                            new Gene(geneValue += mutationStrength, mutatedGenes[genesToMutate[index]].GeneType);
                    }
                }

                if (upOrDown == 1)
                {
                    int geneValue = mutatedGenes[genesToMutate[index]].Value;
                    if (geneValue - mutationStrength <= 0)
                    {
                        mutatedGenes[genesToMutate[index]] =
                            new Gene(geneValue += mutationStrength, mutatedGenes[genesToMutate[index]].GeneType);
                    }
                    else
                    {
                        mutatedGenes[genesToMutate[index]] =
                            new Gene(geneValue -= mutationStrength, mutatedGenes[genesToMutate[index]].GeneType);
                    }
                }
            }

            return new Being(mutatedGenes);
        }
    }
}
