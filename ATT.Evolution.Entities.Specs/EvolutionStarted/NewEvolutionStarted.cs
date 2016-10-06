using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ATT.Evolution.Entities.Specs.EvolutionStarted
{
    [Trait("Evolution is kicked off.","")]
    public class NewEvolutionStarted
    {
        [Fact(DisplayName ="Evolution started.")]
        public void Evolution_Started()
        {
            Evolution evolution = new Evolution(
                numberOfBeings: 1,
                numberOfGenes: 9,
                numberOfSteps: 10);

            Assert.NotNull(evolution);
        }

        [Fact(DisplayName ="Evolution spawns new beings")]
        public void Evolution_Spawns_Beings()
        {
            Evolution evolution = new Evolution(
                numberOfBeings: 1,
                numberOfGenes: 9,
                numberOfSteps: 10);
            Assert.NotNull(evolution.Beings);
        }

        [Fact(DisplayName ="Beings have genes inside them.")]
        public void Beings_have_genes()
        {
            Evolution evolution = new Evolution(
                numberOfBeings: 1,
                numberOfGenes: 9,
                numberOfSteps: 10);

            foreach (Being being in evolution.Beings)
            {
                Assert.NotNull(being.Genes);
            }
        }

        [Fact(DisplayName ="Development of being.")]
        public void Development_of_being()
        {
            Evolution evolution = new Evolution(
                numberOfBeings: 1,
                numberOfGenes: 9,
                numberOfSteps: 10);

            evolution.Start();
        }
    }
}
