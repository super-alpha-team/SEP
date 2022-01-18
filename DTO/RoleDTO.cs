namespace DTO
{
    public class RoleDTO
    {
        private string _id;
        private string _roleName;
        //private List<PermisionDTO> permisions;

        public string RoleName { get => _roleName; set => _roleName = value; }
        //public List<PermisionDTO> Permisions { get => permisions; set => permisions = value; }
        public string Id { get => _id; set => _id = value; }
    }
}