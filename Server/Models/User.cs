using Server.Models;

public class User : BaseModel
{
    /// <summary>
    /// логин пользователя
    /// </summary>
    public string Username { get; set; }
    /// <summary>
    /// пароль пользователя
    /// </summary>
    public string Password { get; set; }
}