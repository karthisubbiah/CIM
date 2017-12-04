namespace CI.Data.Models
{
    public partial class User
    {
        partial void Initialize();
        public User()
        {

            this.Initialize();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}