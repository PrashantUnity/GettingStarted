namespace GettingStarted.Models
{
    public class GraphCellModels
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public int Margin { get; set; } = 1;

        public int BoderWidth { get; set; } = 1;

        public string BoderColor { get; set; } = "green";

        public string  CellColor { get; set; }

        public GraphCellModels Parent { get; set; }   
    }
}
