using System.Collections.Generic;
using System.Linq;
using Users.Domain.Extensions;
using Users.Infrastructure.MDO;

namespace Users.Infrastructure.Extensions
{
    public static class DocumentMapper
    {
        public static UserDocument ToDocument(this Users.Domain.Models.User user)
        {
            return new UserDocument
            {
                Id = user.Id,
                FullName = user.FullName
            };
        }


        public static Users.Domain.Models.User ToModel(this UserDocument user)
        {
            return new Users.Domain.Models.User
            {
                Id = user.Id,
                FullName = user.FullName
            };
        }

        public static IEnumerable<Users.Domain.Models.User> ToModel(this IEnumerable<UserDocument> users)
        {
            if(users.IsNullOrEmptyCollection())
            {
                return Enumerable.Empty<Users.Domain.Models.User>();
            }

            return users.Select(user => user.ToModel());
        }
    }
}
