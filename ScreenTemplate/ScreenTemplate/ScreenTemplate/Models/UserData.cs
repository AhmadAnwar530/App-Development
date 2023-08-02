using SQLite;

namespace ScreenTemplate.Models
{
    public class UserData
    {
        [PrimaryKey]

        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
