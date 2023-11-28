namespace GettingStarted.Models
{
    public class LanguageHolder
    { 
        public List<Snippet> LanguageUrl { get; }

        public LanguageHolder()
        { 
            LanguageUrl = new List<Snippet>();
        }
        public void AddLanguage(LanguageName language, string fileName,string title,string userName="PrashantUnity")
        { 
            LanguageUrl.Add(new Snippet()
            {
                 FileName = fileName,
                 Language = Enum.GetName(language),
                 Title = title,
                 UrserName = userName
            });
        }
    }
}
