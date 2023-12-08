namespace GettingStarted.Models
{
    public class PaintCellModel
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }

        public string CellColor { get; set; }

        public string PreviousCellColor { get; set; } = "white";

    }
}
