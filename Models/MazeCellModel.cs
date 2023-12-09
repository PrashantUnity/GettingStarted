namespace GettingStarted.Models
{
    public class MazeCellModel
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public int Count { get; set; } = 4;
        public string CellColor { get; set; } = "black";

        public List<MazeCellModel> Neighbour { get; set; } = new();
    }
}
