using HttpClientTmpl.BLL.Entities.Users;

namespace HttpClientTmpl.BLL.Entities.Albums;

public class Album
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string Title { get; private set; }
    public User User { get; set; } = null!;
    
    public Album(int id, int userId, string title)
    {
        Id = id;
        UserId = userId;
        Title = title;
    }
}