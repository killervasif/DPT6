public interface ITranslator
{
    void SetNext(ITranslator next);
    bool IsTranslated(string languageFrom, string languageTo);
}

public class TranslatorJpToEn : ITranslator
{
    private ITranslator? _next;
    private string _languageFrom = "japanese";
    private string _languageTo = "english";

    public void SetNext(ITranslator next) => _next = next;

    public bool IsTranslated(string languageFrom, string languageTo)
    {
        if (languageFrom.ToLower() == _languageFrom && languageTo.ToLower() == _languageTo)
            return true;

        return _next is null ? false : _next.IsTranslated(languageFrom, languageTo);
    }
}

public class TranslatorChToEn : ITranslator
{
    private ITranslator? _next;
    private string _languageFrom = "chinese";
    private string _languageTo = "english";

    public void SetNext(ITranslator next) => _next = next;

    public bool IsTranslated(string languageFrom, string languageTo)
    {
        if (languageFrom.ToLower() == _languageFrom && languageTo.ToLower() == _languageTo)
            return true;

        return _next is null ? false : _next.IsTranslated(languageFrom, languageTo);
    }
}

public class TranslatorGerToEn : ITranslator
{
    private ITranslator? _next;
    private string _languageFrom = "germany";
    private string _languageTo = "english";

    public void SetNext(ITranslator next) => _next = next;

    public bool IsTranslated(string languageFrom, string languageTo)
    {
        if (languageFrom.ToLower() == _languageFrom && languageTo.ToLower() == _languageTo)
            return true;

        return _next is null ? false : _next.IsTranslated(languageFrom, languageTo);
    }
}

public class Program
{
    static void Main(string[] args)
    {
        string from = "Chinese";
        string to = "German";


        ITranslator translator1 = new TranslatorGerToEn();
        ITranslator translator2 = new TranslatorChToEn();
        ITranslator translator3 = new TranslatorJpToEn();

        translator1.SetNext(translator2);
        translator2.SetNext(translator3);

        var result = translator1.IsTranslated(from, to);
        Console.WriteLine(result);
    }
}