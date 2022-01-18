namespace DTO
{
    public class UserDTO
    {
        private string _username;
        private string _password;
        //private List<RoleDTO> _roles;
        private string _role;

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Role { get => _role; set => _role = value; }
        //public List<RoleDTO> Roles { get => _roles; set => _roles = value; }

    }
}