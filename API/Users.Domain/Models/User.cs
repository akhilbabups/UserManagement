using System.Collections.Generic;

namespace Users.Domain.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }

    public class Role
    {
        public string Name { get; set; }
    }
}