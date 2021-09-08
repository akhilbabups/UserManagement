using System.Collections.Generic;
using System.Linq;

namespace Users.Test.MockResults
{
    public static class MockReturnResult
    {
        public static IEnumerable<Domain.Models.User> GetMockUsers()
        {
            return new List<Domain.Models.User>
            {
                new Domain.Models.User
                {
                    Id = "7e8df9jsfuwwlw92",
                    FullName ="Akhil",
                    Roles = new List<Domain.Models.Role>
                    {
                        new Domain.Models.Role
                        {
                            Name = "admin"
                        }
                    }
                },
                new Domain.Models.User
                {
                    Id = "7e8df9jsfuwwlw93",
                    FullName ="Arun",
                    Roles = new List<Domain.Models.Role>
                    {
                        new Domain.Models.Role
                        {
                            Name = "admin"
                        },
                        new Domain.Models.Role
                        {
                            Name = "Manager"
                        }
                    }
                }
            };
        }
        public static IEnumerable<Domain.Models.User> GetMockUsersNullOrEmptyList(bool isNull)
        {
            return isNull ? null : Enumerable.Empty<Domain.Models.User>();
        }

        public static Domain.Models.User GetNewUser(bool isNameRequired = true)
        {
            return new Domain.Models.User
            {
                FullName = isNameRequired ? "Arjun" : null,
                Roles = new List<Domain.Models.Role>
                    {
                        new Domain.Models.Role
                        {
                            Name = "admin"
                        },
                        new Domain.Models.Role
                        {
                            Name = "Manager"
                        }
                    }
            };
        }

        public static Domain.Models.User GetNewUserResponse()
        {
            return new Domain.Models.User
            {
                Id = "7e8df9jsfuwwlw94",
                FullName = "Arjun",
                Roles = new List<Domain.Models.Role>
                    {
                        new Domain.Models.Role
                        {
                            Name = "admin"
                        },
                        new Domain.Models.Role
                        {
                            Name = "Manager"
                        }
                    }
            };
        }
    }
}
