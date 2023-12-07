namespace GettingStarted.Models
{
    public class GraphCellModels
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }

        public string  CellColor { get; set; }

        public GraphCellModels Parent { get; set; }   
    }
}
