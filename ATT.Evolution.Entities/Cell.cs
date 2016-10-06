using System.Collections.Generic;

namespace ATT.Evolution.Entities
{
    public class Cell
    {
        public List<Gene> Genes { get; set; }

        public Cell(List<Gene> genes)
        {
            this.Genes = genes;
        }
    }
}