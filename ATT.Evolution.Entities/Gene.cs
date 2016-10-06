namespace ATT.Evolution.Entities
{
    public enum GeneType
    {
        Angle,
        Length,
        Thickness,
        Color
    }

    public  class Gene
    {
        public GeneType GeneType { get; set; }
        public int Value { get; set; }

        public Gene(int value, GeneType geneType)
        {
            this.Value = value;
            this.GeneType = geneType;
        }

    }
}