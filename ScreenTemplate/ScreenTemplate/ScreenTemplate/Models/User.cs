using SQLite;

namespace ScreenTemplate.Models
{
    public class User
    {
        [PrimaryKey]

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
