namespace GettingStarted.Models
{
    public class Snippet
    {
        public string Language { get; set; } = Enum.GetName(LanguageName.CSharp); 
        public string Title { get; set; }
        public string FileName { get; set; }

        public string UrserName { get; set; } = "PrashantUnity";
    }
}
