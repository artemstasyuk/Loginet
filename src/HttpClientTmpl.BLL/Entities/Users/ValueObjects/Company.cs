namespace HttpClientTmpl.BLL.Entities.Users.ValueObjects;

public class Company
{

    public string Name { get; set; }
    public string CatchPhrase { get; set; }
    public string Bs { get; set; }
    
    public Company(string name, string catchPhrase, string bs)
    {
        Name = name;
        CatchPhrase = catchPhrase;
        Bs = bs;
    }
}
