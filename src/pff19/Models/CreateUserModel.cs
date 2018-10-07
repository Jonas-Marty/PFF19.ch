namespace pff19.Models
{
    public class CreateUserModel
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string ScoutName { get; set; }
        public string Mail { get; set; }
        public string Ressort { get; set; }
        public bool IsAdmin { get; set; }
    }
}
