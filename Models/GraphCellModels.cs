namespace GettingStarted.Models
{
    public class GraphCellModels
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }

        public string  CellColor { get; set; }

        public bool StartingPoint { get; set; } = false;

        public bool EndingPoint { get; set;} = false;

        public bool MyProperty { get; set; }=true;
    }
}
