namespace GettingStarted.Models
{
    public class Snippet
    {
        public string HeadingName { get; set; } = "Code";
        public string BoderColor { get; set; } = "black";
        public int BoderThickNess { get; set; } = 0; 
        public int HeightOfFrame { get; set; } = 500;
        public string Language { get; set; } = Enum.GetName(LanguageName.CSharp);

        public string SourceUrl { get; set; } = "https://pastebin.com/embed_iframe/YBZtRsfb";
    }
}
